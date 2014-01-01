// regedit.go - Various winapi function to scan/query the registry. Credits to AllenDang @ https://github.com/AllenDang/w32
package main

import (
	"syscall"
	"unsafe"
)

const (
	// Top level key constants
	HKEY_LOCAL_MACHINE HKEY = 0x80000002
	// Registry access rights
	KEY_ENUMERATE_SUB_KEYS = 0x0008
	KEY_QUERY_VALUE        = 0x0001
	// Registry value types
	RRF_RT_REG_SZ = 0x00000002
	// Registry paths
	KEYBOARD_LAYOUTS = "SYSTEM\\CurrentControlSet\\Control\\Keyboard Layouts"
)

type (
	HKEY HANDLE
)

var (
	modadvapi32      = syscall.NewLazyDLL("advapi32.dll")
	procRegOpenKeyEx = modadvapi32.NewProc("RegOpenKeyExW")
	procRegEnumKeyEx = modadvapi32.NewProc("RegEnumKeyExW")
	procRegGetValue  = modadvapi32.NewProc("RegGetValueW")
)

// regOpenKeyEx opens the specified registry key. Note that key names are not case sensitive.
func regOpenKeyEx(hKey HKEY, subKey string, samDesired uint32) (HKEY, int) {
	var result HKEY
	ret, _, _ := procRegOpenKeyEx.Call(
		uintptr(hKey),
		uintptr(unsafe.Pointer(syscall.StringToUTF16Ptr(subKey))),
		uintptr(0),
		uintptr(samDesired),
		uintptr(unsafe.Pointer(&result)))

	if ret != 0 {
		return result, -1
	}
	return result, 0
}

// regEnumKeyEx enumerates the subkeys of the specified open registry key.
// The function retrieves information about one subkey each time it is called.
func regEnumKeyEx(hKey HKEY, index uint32) string {
	var bufLen uint32 = 255
	buf := make([]uint16, bufLen)
	procRegEnumKeyEx.Call(
		uintptr(hKey),
		uintptr(index),
		uintptr(unsafe.Pointer(&buf[0])),
		uintptr(unsafe.Pointer(&bufLen)),
		0,
		0,
		0,
		0)
	return syscall.UTF16ToString(buf)
}

// regGetString retrieves the data of the specified registry value.
// This is a helper function wrapping regGetValue.
func regGetString(hKey HKEY, subKey string, value string) string {
	var bufLen uint32
	procRegGetValue.Call(
		uintptr(hKey),
		uintptr(unsafe.Pointer(syscall.StringToUTF16Ptr(subKey))),
		uintptr(unsafe.Pointer(syscall.StringToUTF16Ptr(value))),
		uintptr(RRF_RT_REG_SZ),
		0,
		0,
		uintptr(unsafe.Pointer(&bufLen)))

	if bufLen == 0 {
		return ""
	}

	buf := make([]uint16, bufLen)
	ret, _, _ := procRegGetValue.Call(
		uintptr(hKey),
		uintptr(unsafe.Pointer(syscall.StringToUTF16Ptr(subKey))),
		uintptr(unsafe.Pointer(syscall.StringToUTF16Ptr(value))),
		uintptr(RRF_RT_REG_SZ),
		0,
		uintptr(unsafe.Pointer(&buf[0])),
		uintptr(unsafe.Pointer(&bufLen)))

	if ret != 0 {
		return ""
	}

	return syscall.UTF16ToString(buf)
}

// Helpers

func constructRegPath(s string) string {
	return KEYBOARD_LAYOUTS + "\\" + s
}
