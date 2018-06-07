# ALTTPR Crop Dashboard Guide

This program was made to hopefully make cropping for restreams faster by providing an easy way to interact with OBS as well as have a database of crops to at least get a starting point from.

While this won’t be a perfect system it will hopefully still save time due to having a much better starting point for the crops.  All that is needed is to download and install OBS WebSocket (https://github.com/Palakis/obs-websocket/releases/tag/4.3.3)

Below are some screenshots along with what the various portions of those screens are.

## Main User Settings:



This should be the first screen you come across.  It’s a way of setting what each section of the program will control.

Twitch Channel / User Name - This will be the name that the crops get submitted as.  This is useful as we use this to prioritize what crops get picked as default based on the name and when it was submitted.

Default / Custom - This is the way to connect to the OBS WebSocket.  Default should be used unless you changed the port or added a password.
Verify / Connect - This will verify that the port to connect is open and, if so, connect you to OBS.

Refresh OBS Scenes - This shouldn’t be needed unless, while you are connected, you re-name or add sources to your OBS scene.

The various drop downs - These are where you’re going to set which source name in OBS matches which area of the screen.  There is some type checking to make sure you use the correct source type.  An example of this is if you are trying to set a text source when the program expects a browser source.  It will warn you and will not save that field.

Reset Settings - This will reset your default settings

Save and Continue - You have 2 options depending when in the process you access the settings screen.  The first time you load the program you will have the option to continue to the VLC settings page or just go right to the program.  After saving the first time you just have a save and continue to the program.




VLC Settings:



I have a menu bar - This should never really be un-checked.  This means you have a menu bar at the top.  Most of the time this should always be true.

I have controls - This should also usually be checked.  This means you have the play/pause controls active.

I have a status bar - This one is usually not needed.  If you have a status bar, you should check this.

Override - If you have more or less controls/menus at the top or bottom you would likely need to check this an input your own values.  This is important as before saving the crop we remove these numbers and re-add them from other peoples crops to get the most accurate game window size as possible.

To get the values for your system, open VLC and set it as a source with the correct bounding box/size/area.  After that, crop out the top and bottom menu and make a note of what values those are.



Main Window:

One thing to note, the sections are basically colour coded with the button that affects them.



Connect OBS 1 - This is to connect to OBS with the saved connection settings.  Before anything is allowed to be done in the program you have to connect to OBS.  There is currently a way being tested to connect to multiple OBS instances at a time but nothing fully finished yet.

Set Track/Comms/Names - This will set the text boxes of OBS to match the commentary text box and the runner name drop downs as well as the tracker URL from the text boxes.  If any of them are left blank, or there was no setting saved, it just does nothing for that area.

For the runners, just pick from the drop down, if it exists, or click the “New Runner” button.  For the tracker URL and the commentary names, just copy and paste.

New Runner - This will open a new form (shown later) that will allow you to type in the runner name as well as the twitch name.  If it exists, it will select it from the list otherwise fills in the info to save.

Get Processes - This will check the current running processes to see what VLC windows are running.  This will make it easier to set the game/timer windows to the proper runner

Set VLC - This will set the proper sources to the VLC processes as long as the proper source names were set in the settings

Get Crop - This will poll the OBS timer/game sources for their current crop settings and fill them in into the proper text boxes

Save Crop - This will save the numbers in the crop text boxes to the selected runner into the local database

Set Crop - This will set the crop settings of the sources in OBS.  After selecting the runner in the drop down if there is crop data it will populate the text boxes and then all that is needed is hitting set crop.  Be warned that depending on how accurate the numbers are for VLC for the person who saved the crop there may be a bit of fine tuning needed but you can then save your numbers and it will prioritize those over anyone else's

Sync With Server - This will send any new crops you have done to the main server while also grabbing new crops that other people have done to the local database

IMPORTANT NOTE:  When you do your own crop, or are tweaking someone else's crop, it is important that the OBS window has no black bars on any side (Left, Top, Right, Bottom) because of resizing VLC.  If there are black bars it will not look right when someone else uses that crop.


New Runner Window:



Twitch Name - This field if needed.  This is the twitch channel name that you are grabbing the crop from

Runner Name - This field is optional.  If it is the same as the twitch name, you can leave it blank and it will just use the twitch name.  If it is different, please enter what the runner name is.  This is what will show up in the drop down

Adjust crop in OBS - If the runner exists currently in the system, checking this checkbox will automatically set OBS to be what is in the system as soon as the window is closed.  This only affects runners already in the database.

Reuse information - If checked, it will bring in the crop information into the text boxes in the main screen.  Most of the time you’ll want this checked.  If unchecked it will bring in the names but leave the text boxes blank in case it is a new crop and you want to start from scratch.  If checked and it is a new runner, it will just use blank information anyway.



Other Notes:

Current the program works pretty well.  There may be things that don’t quite behave how they should but it is in a state that is good for an initial release.

There is an option for expert settings.  This includes some features that is being tested but may cause issues/not work right.  Use at your own risk.

To sync with the online server you will need a config file and place it manually in the program folder.  If you get this file, please treat it like the stream keys and not share this file with others even if they are restreamers.  Let the proper people send the file out.

This is the first program I’ve released as well as working with a local database.  As such I haven’t found a way to install it and run with the database running outside the install location.  As such, for the initial version of the program it will need to be run as administrator.  I am sorry for this requirement and I’ll do my best to fix this but it will be a work in progress.
