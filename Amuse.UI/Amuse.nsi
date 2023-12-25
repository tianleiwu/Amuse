; Amuse.nsi
;
; This script is based on Amuse.nsi but it remembers the directory, 
; has uninstall support and (optionally) installs start menu shortcuts.
;
; It will install example2.nsi into a directory that the user selects.
;
; See install-shared.nsi for a more robust way of checking for administrator rights.
; See install-per-user.nsi for a file association example.

;--------------------------------
!define BUILD_VERSION "v0.1.0"
!define BUILD_NAME "CPU"

!define BUILD_FOLDER "D:\Build\Amuse"
!define MUI_ICON    "${BUILD_FOLDER}\Assets\Icon.ico"
!define MUI_UNICON  "${BUILD_FOLDER}\Assets\Icon.ico"

!include "MUI2.nsh"

; The name of the installer
Name "Amuse"

; The file to write
OutFile "Amuse_${BUILD_VERSION}_${BUILD_NAME}.exe"

; Request application privileges for Windows Vista and higher
RequestExecutionLevel admin

; Build Unicode installer
Unicode True

; The default installation directory
InstallDir $PROGRAMFILES64\Amuse

; Registry key to check for directory (so if you install again, it will 
; overwrite the old one automatically)
InstallDirRegKey HKLM "Software\Amuse" "Install_Dir"

;--------------------------------

; Pages

!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES

!insertmacro MUI_LANGUAGE "English"

UninstPage uninstConfirm
UninstPage instfiles

;--------------------------------

; The stuff to install
Section "Amuse (required)"

  SectionIn RO
  
  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  ; Put file there
  File "${BUILD_FOLDER}\Amuse_${BUILD_NAME}\*.*"
  File "${BUILD_FOLDER}\Amuse_${BUILD_NAME}\runtimes\win-x64\native\*.*"
  
  ; Write the installation path into the registry
  WriteRegStr HKLM SOFTWARE\NSIS_Amuse "Install_Dir" "$INSTDIR"
  
  ; Write the uninstall keys for Windows
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Amuse" "DisplayName" "Amuse"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Amuse" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Amuse" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\EAmuse" "NoRepair" 1
  WriteUninstaller "$INSTDIR\uninstall.exe"
  
SectionEnd

; Optional section (can be disabled by the user)
Section "Start Menu Shortcuts"

  CreateDirectory "$SMPROGRAMS\Amuse"
  CreateShortcut "$SMPROGRAMS\Amuse\Uninstall.lnk" "$INSTDIR\uninstall.exe"
  CreateShortcut "$SMPROGRAMS\Amuse\Amuse.lnk" "$INSTDIR\Amuse.exe"

SectionEnd

;--------------------------------

; Uninstaller

Section "Uninstall"
  
  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Amuse"
  DeleteRegKey HKLM SOFTWARE\Amuse

  ; Remove files and uninstaller
  Delete $INSTDIR\*.*
  Delete $INSTDIR\uninstall.exe

  ; Remove shortcuts, if any
  Delete "$SMPROGRAMS\Amuse\*.lnk"

  ; Remove directories
  RMDir "$SMPROGRAMS\Amuse"
  RMDir "$INSTDIR"

SectionEnd

