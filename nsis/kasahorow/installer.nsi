!include FontRegAdv.nsh
!include FontName.nsh

!define LANGNAME "Kasahorow"
!define APPNAME "Kasahorow Keyboard"
!define COMPANYNAME "kasahorow"
!define HELPURL "http://kasahorow.org/${LANGNAME}/keyboard"

#display title on the installer
Name "${COMPANYNAME} - ${APPNAME}"
Icon "kasahorow.ico"

# Name of the output file
outFile "${LANGNAME}.exe"
InstallDir "$PROGRAMFILES\${COMPANYNAME}\${LANGNAME}"



# installation section
section "install"

	#SetOutPath $INSTDIR
	#File "uninstall.exe"

	SetOutPath $INSTDIR\keyboard	
	
	File "keyboard\setup.exe"
	File "keyboard\*.msi"
	File /r "keyboard\*.dll"
	
	File "kasahorow.ico"

	ExecWait "$INSTDIR\keyboard\setup.exe"
	
	#fonts
	StrCpy $FONT_DIR "$INSTDIR\fonts"
	
	!insertmacro InstallTTF 'fonts\DejaVuSans.ttf'
	!insertmacro InstallTTF 'fonts\DejaVuSans-Bold.ttf'
	!insertmacro InstallTTF 'fonts\DejaVuSans-BoldOblique.ttf'
	!insertmacro InstallTTF 'fonts\DejaVuSansCondensed.ttf'
	!insertmacro InstallTTF 'fonts\DejaVuSansCondensed-Bold.ttf'
	!insertmacro InstallTTF 'fonts\DejaVuSansCondensed-BoldOblique.ttf'
	!insertmacro InstallTTF 'fonts\DejaVuSansCondensed-Oblique.ttf'
	!insertmacro InstallTTF 'fonts\DejaVuSans-ExtraLight.ttf'
	!insertmacro InstallTTF 'fonts\DejaVuSansMono.ttf'
	!insertmacro InstallTTF 'fonts\DejaVuSansMono-Bold.ttf'
	!insertmacro InstallTTF 'fonts\DejaVuSansMono-BoldOblique.ttf'
	!insertmacro InstallTTF 'fonts\DejaVuSansMono-Oblique.ttf'
	!insertmacro InstallTTF 'fonts\DejaVuSerif.ttf'
	!insertmacro InstallTTF 'fonts\DejaVuSerif-Bold.ttf'
	!insertmacro InstallTTF 'fonts\DejaVuSerif-Italic.ttf'
	!insertmacro InstallTTF 'fonts\DejaVuSerif-BoldItalic.ttf'
	!insertmacro InstallTTF 'fonts\DejaVuSerifCondensed.ttf'
	!insertmacro InstallTTF 'fonts\DejaVuSerifCondensed-Bold.ttf'
	!insertmacro InstallTTF 'fonts\DejaVuSerifCondensed-BoldItalic.ttf'
	!insertmacro InstallTTF 'fonts\DejaVuSerifCondensed-Italic.ttf'
	!insertmacro InstallTTF 'fonts\DoulosSILR.ttf'
	!insertmacro InstallTTF 'fonts\GenAI102.TTF'
	!insertmacro InstallTTF 'fonts\GenAR102.TTF'
	!insertmacro InstallTTF 'fonts\GenI102.TTF'
	!insertmacro InstallTTF 'fonts\GenR102.TTF'
	
	#FindFirst $0 $1 $INSTDIR\fonts\*.ttf
	#loop:
	#	StrCmp $1 "" done
	#	!insertmacro InstallTTF "$1" 
	#	FindNext $0 $1
	#	Goto loop
	#done:
	#	FindClose $0

	# define uninstaller name
	writeUninstaller $INSTDIR\uninstaller.exe

	# Shortcut menu
	CreateDirectory "$SMPROGRAMS\${COMPANYNAME}"
	CreateShortCut "$SMPROGRAMS\${COMPANYNAME}\${APPNAME}.lnk" "${HELPURL}" "" "$INSTDIR\kasahorow.ico"
	CreateShortCut "$SMPROGRAMS\${COMPANYNAME}\Uninstall ${APPNAME}.lnk" "$INSTDIR\uninstaller.exe" "" "$INSTDIR\Uninstall.exe" 0
	
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${COMPANYNAME}\${LANGNAME}" "DisplayName" "${COMPANYNAME} - ${APPNAME}"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${COMPANYNAME}\${LANGNAME}" "UninstallString" "$\"$INSTDIR\uninstaller.exe$\""
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${COMPANYNAME}\${LANGNAME}" "QuietUninstallString" "$\"$INSTDIR\uninstaller.exe$\" /S"
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${COMPANYNAME}\${LANGNAME}" "InstallLocation" "$\"$INSTDIR$\""
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${COMPANYNAME}\${LANGNAME}" "DisplayIcon" "$\"$INSTDIR\kasahorow.ico$\""
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${COMPANYNAME}\${LANGNAME}" "Publisher" "$\"${COMPANYNAME}$\""
	WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${COMPANYNAME}\${LANGNAME}" "HelpLink" "$\"${HELPURL}$\""
			
sectionEnd

#Uninstall section
Section "Uninstall"
	StrCpy $FONT_DIR "$INSTDIR\fonts"

#	Plugin developer's note:RemoveTTF macro doesn't work at the moment. 	
#	!insertmacro RemoveTTF 'DejaVuSans.ttf'
#	!insertmacro RemoveTTF 'fonts\DejaVuSans-Bold.ttf'
#	!insertmacro RemoveTTF 'fonts\DejaVuSans-BoldOblique.ttf'
#	!insertmacro RemoveTTF 'fonts\DejaVuSansCondensed.ttf'
#	!insertmacro RemoveTTF 'fonts\DejaVuSansCondensed-Bold.ttf'
#	!insertmacro RemoveTTF 'fonts\DejaVuSansCondensed-BoldOblique.ttf'
#	!insertmacro RemoveTTF 'fonts\DejaVuSansCondensed-Oblique.ttf'
#	!insertmacro RemoveTTF 'fonts\DejaVuSans-ExtraLight.ttf'
#	!insertmacro RemoveTTF 'fonts\DejaVuSansMono.ttf'
#	!insertmacro RemoveTTF 'fonts\DejaVuSansMono-Bold.ttf'
#	!insertmacro RemoveTTF 'fonts\DejaVuSansMono-BoldOblique.ttf'
#	!insertmacro RemoveTTF 'fonts\DejaVuSansMono-Oblique.ttf'
#	!insertmacro RemoveTTF 'fonts\DejaVuSerif.ttf'
#	!insertmacro RemoveTTF 'fonts\DejaVuSerif-Bold.ttf'
#	!insertmacro RemoveTTF 'fonts\DejaVuSerif-Italic.ttf'
#	!insertmacro RemoveTTF 'fonts\DejaVuSerif-BoldItalic.ttf'
#	!insertmacro RemoveTTF 'fonts\DejaVuSerifCondensed.ttf'
#	!insertmacro RemoveTTF 'fonts\DejaVuSerifCondensed-Bold.ttf'
#	!insertmacro RemoveTTF 'fonts\DejaVuSerifCondensed-BoldItalic.ttf'
#	!insertmacro RemoveTTF 'fonts\DejaVuSerifCondensed-Italic.ttf'
#	!insertmacro RemoveTTF 'fonts\DoulosSILR.ttf'
#	!insertmacro RemoveTTF 'fonts\GenAI102.TTF'
#	!insertmacro RemoveTTF 'fonts\GenAR102.TTF'
#	!insertmacro RemoveTTF 'fonts\GenI102.TTF'
#	!insertmacro RemoveTTF 'fonts\GenR102.TTF'

	FindFirst $0 $1 $INSTDIR\keyboard\*.msi
	loop:
		StrCmp $1 "" done
		ExecWait '"msiexec" /quiet /x "$INSTDIR\keyboard\$1"'
		FindNext $0 $1
		Goto loop
	done:
		FindClose $0

	# Remove Start Menu 
	delete "$SMPROGRAMS\${COMPANYNAME}\${APPNAME}.lnk"
	delete "$SMPROGRAMS\${COMPANYNAME}\Uninstall ${APPNAME}.lnk"
	rmdir "$SMPROGRAMS\${COMPANYNAME}"
		
	delete  $INSTDIR\uninstaller.exe
	delete 	$INSTDIR\kasahorow.ico
	rmdir /r $INSTDIR
	
	DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\${COMPANYNAME}\${LANGNAME}"
SectionEnd

