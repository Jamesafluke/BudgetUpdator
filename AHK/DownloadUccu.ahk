#SingleInstance force
Esc::ExitApp
;Variables
;The login page has one type of banner. All the pages after that have a maintenance banner.
;Login page banner is y93 to y237. 144 pixels tall. 
;Maintenance banner is y162 to y232. 70 pixels tall.



littleBannerColor := "0x001E3C"
xLittleBanner := 1599
yLittleBanner := 213
xCloseLittleBanner := 1687
yCloseLittleBanner := 201
; tabToExport := 3
; tabToCsv := 2

xBack := 1366
yBack := 154


; Run 'C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe' "https://uccu.com"
Run "C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe https://uccu.com --new-window"
; Run "msedge.exe www.google.com/ --new-window"
Sleep 10000

;Click sign in.
Send "{Enter}"
Sleep 10000

;Rewards
;5
Send "{Tab}"
Sleep 200
Send "{Tab}"
Sleep 200
Send "{Tab}"
Sleep 200
Send "{Tab}"
Sleep 200
Send "{Tab}"
Sleep 200
Send "{Enter}"
Sleep 20000

;Download
Send "{Tab 3}"
Sleep 200
Send "{Enter}"
Sleep 200
Send "{Tab 2}"
Sleep 200
Send "{Enter}"
Sleep 30000

;Back
Send "+{Tab 4}"
Sleep 200
Send "{Enter}"
Sleep 20000


;Checking
;9
Send "{Tab}"
Sleep 200
Send "{Tab}"
Sleep 200
Send "{Tab}"
Sleep 200
Send "{Tab}"
Sleep 200
Send "{Tab}"
Sleep 200
Send "{Tab}"
Sleep 200
Send "{Tab}"
Sleep 200
Send "{Tab}"
Sleep 200
Send "{Tab}"
Sleep 200
Send "{Enter}"
Sleep 20000

;Download
Send "{Tab 4}"
Sleep 200
Send "{Enter}"
Sleep 200
Send "{Tab 2}"
Sleep 200
Send "{Enter}"
Sleep 30000


Send "^w"

Exit