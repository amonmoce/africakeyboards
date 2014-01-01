// winapi.go - Various winapi functions to handle keyboard layout switching, etc. Credits to AllenDang @ https://github.com/AllenDang/w32
package main

import (
	"syscall"
	"unsafe"
)

const (
	KFL_SETFORPROCESS = 0x00000100
)

type (
	HANDLE uintptr
	HKL    HANDLE
)

var (
	moduser32                  = syscall.NewLazyDLL("user32")
	procGetKeyboardLayoutList  = moduser32.NewProc("GetKeyboardLayoutList")
	procActivateKeyboardLayout = moduser32.NewProc("ActivateKeyboardLayout")
	procGetKeyboardLayout      = moduser32.NewProc("GetKeyboardLayout")
	procGetKeyboardLayoutName  = moduser32.NewProc("GetKeyboardLayoutNameW")
)

// Retrieves the input locale identifiers (formerly called keyboard layout handles)
// corresponding to the current set of input locales in the system.
// The function copies the identifiers to the specified buffer.
func getKeyboardLayoutList(nBuf int) (int, []HKL) {
	buf := make([]HKL, nBuf)
	ret, _, _ := procGetKeyboardLayoutList.Call(
		uintptr(nBuf),
		uintptr(unsafe.Pointer(&buf[0])))
	return int(ret), buf
}

// getKeyboardLayout retrieves the active input locale identifier (formerly called the keyboard layout).
func getKeyboardLayout() HKL {
	ret, _, _ := procGetKeyboardLayout.Call(
		uintptr(0))

	return HKL(ret)
}

// getKeyboardLayoutList retrieves the name of the active input locale identifier
// (formerly called the keyboard layout) for the system.
func getKeyboardLayoutName() string {
	buf := make([]uint16, 9)
	procGetKeyboardLayoutName.Call(
		uintptr(unsafe.Pointer(&buf[0])))
	return syscall.UTF16ToString(buf)
}

// Sets the input locale identifier (formerly called the keyboard layout handle)
// for the calling thread or the current process.
// The input locale identifier specifies a locale as well as the physical layout of the keyboard.
func activateKeyboardLayout(hkl HKL, flag uint) uintptr {
	ret, _, _ := procActivateKeyboardLayout.Call(
		uintptr(hkl),
		uintptr(flag))
	return ret
}
