//keyboard.go - holds the main entry function. Do not build directly, use provided tool.
package main

import (
	"github.com/lxn/walk"
	. "github.com/lxn/walk/declarative"
	"strings"
)

// Tool generated, DO NOT EDIT.
const (
	LANG_ID     = "{{.LangId}}"     // Unique langauge identifier.
	LANG_STRING = "{{.LangString}}" // Language name used in varioud labels.
	INFO_TEXT   = `{{.InfoText}}`   // Help text for info label.
)

var (
	LANG = "00000409" // Default US keyboard.
)

// Helpers

// loadLangage loads a new keyboard layout in the main GUI thread.
func loadLanguage() {
	ret, buf := getKeyboardLayoutList(100)
	if ret == 0 {
		return
	}
	for i := 0; i < ret; i++ {
		activateKeyboardLayout(buf[i], KFL_SETFORPROCESS)
		if LANG == getKeyboardLayoutName() {
			return
		}
	}
}

// checkAndLoadLanguage checks if the language defined by LANG is
// present on the system and loads it subsequently.
func checkLanguage() bool {
	ret, buf := getKeyboardLayoutList(100)
	if ret == 0 {
		return false
	}
	for i := 0; i < ret; i++ {
		activateKeyboardLayout(buf[i], KFL_SETFORPROCESS)
		if LANG == getKeyboardLayoutName() {
			return true
		}
	}
	return false
}

// queryRegLayoutId scans the "Keyboard Layouts" registry key
// returning the language identifier mathching the provided human readable langauge name.
func queryRegLayoutId(layout string) string {
	var i uint32 = 1
	top, res := regOpenKeyEx(HKEY_LOCAL_MACHINE, KEYBOARD_LAYOUTS, KEY_ENUMERATE_SUB_KEYS)
	if res != 0 {
		return ""
	}
	for name := regEnumKeyEx(top, 0); name != ""; i++ {
		name = regEnumKeyEx(top, i)
		value := regGetString(top, name, "langId")
		if value == layout {
			return strings.ToUpper(name)
		}
	}
	return ""
}

// Main entry and GUI construction
func main() {
	LANG = queryRegLayoutId(LANG_ID)
	var (
		mw            *walk.MainWindow
		currentLayout = getKeyboardLayout() // Get current system layout.
		layoutPresent = checkLanguage()     // Check if installed language is present and can be loaded.
		triggered     = true
		infoText      string
		ldtMain       *walk.LineEdit
		btnMain       *walk.PushButton
	)

	if layoutPresent {
		infoText = INFO_TEXT
	} else {
		infoText = "The layout does not seem to be present on your system. Please install it first."
	}

	MainWindow{
		AssignTo: &mw,
		Title:    "kasahorow " + LANG_STRING + " Writer",
		MaxSize:  Size{600, 200},
		MinSize:  Size{600, 200},
		Layout:   VBox{},
		Children: []Widget{
			MultilineLabel{Text: infoText},
			LineEdit{AssignTo: &ldtMain},
			PushButton{
				AssignTo: &btnMain,
				Enabled:  layoutPresent,
				Text:     "Switch back to default layout.",
				OnClicked: func() {
					if triggered {
						triggered = false
						activateKeyboardLayout(currentLayout, KFL_SETFORPROCESS)
						btnMain.SetText("Switch to " + LANG_STRING + ".")
					} else {
						triggered = true
						loadLanguage()
						btnMain.SetText("Switch back to default layout.")
					}
				},
			},
		},
	}.Create()

	if layoutPresent {
		mw.Synchronize(loadLanguage) // Load new layout in main GUI thread.
	}

	ic, _ := walk.NewIconFromResource("kasahorow")
	mw.SetIcon(ic)
	mw.Run()
}
