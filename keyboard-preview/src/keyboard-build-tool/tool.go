package main

import (
	"bytes"
	"encoding/json"
	"io/ioutil"
	"log"
	"os"
	"os/exec"
	"path"
	"strings"
	"text/template"
)

type ConfigEntry struct {
	LangHuReadable, LangString, InfoText string
}

type Config []ConfigEntry

func main() {
	var (
		err         error
		gopath      string = ""
		sourcedir   string = ""
		sourcefiles        = []string{"keyboard.go", "regedit.go", "winapi.go", "multilinelabel.go", "rsrc.syso"}
		mainsource  string
	)
	log.Println("Kasaharow keyboard build tool.")
	log.Println("Performing sanity checks.")
	// Various sanity checks.
	if _, err = exec.LookPath("go"); err != nil {
		log.Fatal("'Go' buildchain does not seem to be installed or is missing from PATH env variable. Aborting.")
	}
	if _, err = exec.LookPath("git"); err != nil {
		log.Fatal("'Git' does not seem to be installed or is missing from PATH env variable. Aborting.")
	}
	if gopath = os.Getenv("GOPATH"); gopath == "" {
		log.Fatal("GOPATH env variable not set. Aborting.")
	}
	if _, err = os.Stat("./config.json"); os.IsNotExist(err) {
		log.Fatal("config.json not present in current directory. Aborting.")
	}
	if _, err = os.Stat(path.Join(gopath, "bin", "win-386", "keyboard-bin")); os.IsNotExist(err) {
		log.Println("Bin directory missing. Creating.")
		os.MkdirAll(path.Join(gopath, "bin", "win-386", "keyboard-bin"), 0666)
	}
	sourcedir = path.Join(gopath, "src", "keyboard")
	if _, err := os.Stat(sourcedir); os.IsNotExist(err) {
		log.Fatal("'keyboard' source directory missing from GOPATH. Aborting.")
	}
	for _, sfile := range sourcefiles {
		if _, err := os.Stat(path.Join(gopath, "src", "keyboard", sfile)); os.IsNotExist(err) {
			log.Fatal("'" + sfile + "source file missing from 'keyboard' source directory. Aborting.")
		}
	}
	mainsource = path.Join(gopath, "src", "keyboard", "keyboard.go")
	if _, err := os.Stat(path.Join(gopath, "src", "github.com", "lxn", "walk")); os.IsNotExist(err) {
		log.Println("'Walk' winapi wrappers missing from GOPATH. Will try downloading and installing.")
		cmd := exec.Command("go", "get", "github.com/lxn/walk")
		var out bytes.Buffer
		cmd.Stdout = &out
		err := cmd.Run()
		if err != nil {
			log.Fatal(err)
		}
		if out.String() != "" {
			log.Fatal("Install failed... Try installing by hand with 'go get github.com/lxn/walk'")
		}
		log.Println("Walk was installed.")
	}

	//Process config file and build the tools.
	log.Println("Reading config and building main template.")
	data, err := ioutil.ReadFile("./config.json")
	if err != nil {
		log.Fatal(err)
	}
	source, err := ioutil.ReadFile(mainsource)
	if err != nil {
		log.Fatal(err)
	}
	tmpl, err := template.New("main").Parse(string(source))
	if err != nil {
		log.Println("Failed to generate main template. Aborting.")
		log.Fatal(err)
	}
	var config Config
	json.Unmarshal(data, &config)
	if len(config) == 0 {
		log.Fatal("Read 0 config entries. Malformed config file?. Aborting.")
	}
	log.Println("Read", len(config), "entries.")
	log.Println("Generating binaries.")
	for _, entry := range config {
		log.Println("Proccessing", entry.LangString)
		os.Remove(path.Join(gopath, "src", "tmp"))
		os.Mkdir(path.Join(gopath, "src", "tmp"), 0666)
		fo, err := os.Create(path.Join(gopath, "src", "tmp", "keyboard.go"))
		if err != nil {
			log.Println("Couldn't create main source file. Check directory permissions?")
			log.Fatal(err)
		}
		tmpl.Execute(fo, entry)
		fo.Close()
		for i, f := range sourcefiles {
			if i > 0 {
				in, err := ioutil.ReadFile(path.Join(gopath, "src", "keyboard", f))
				if err != nil {
					log.Println("Couldn't read source file", f)
					log.Fatal(err)
				}
				err = ioutil.WriteFile(path.Join(gopath, "src", "tmp", f), in, 0644)
				if err != nil {
					log.Println("Couldn't copy source file", f, "Check directory permissions?")
					log.Fatal(err)
				}
			}
		}
		log.Println("Generated template files", entry.LangString)
		log.Println("Building", entry.LangString)
		os.Chdir(path.Join(gopath, "src", "tmp"))
		cmd := exec.Command("go", "build", "-ldflags", "-H windowsgui", "tmp")
		var out bytes.Buffer
		cmd.Stderr = &out
		err = cmd.Run()
		if err != nil {
			log.Println(out.String())
			log.Fatal(err)
		}
		sanitized := strings.ToLower(strings.Replace(entry.LangString, " ", "", -1))
		in, err := ioutil.ReadFile(path.Join(gopath, "src", "tmp", "tmp.exe"))
		if err != nil {
			log.Println("Couldn't read binary file.", entry.LangString)
			log.Fatal(err)
		}
		err = ioutil.WriteFile(path.Join(gopath, "bin", "win-386", "keyboard-bin", "keyboard-"+sanitized+".exe"), in, 0644)
		if err != nil {
			log.Println("Couldn't copy binary file.", entry.LangString, "Check directory permissions?")
			log.Fatal(err)
		}
		log.Println("Exported", entry.LangString, path.Join("bin", "win-386", "keyboard-bin", "keyboard-"+sanitized+".exe"))
	}
	log.Println("Done. Cleaning...")
	os.Remove(path.Join(gopath, "src", "tmp"))
	log.Println("Finished!")
}
