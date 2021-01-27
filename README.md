# DEPRECATED

This code will no longer be maintained.  It started with good intentions to help save time with cropping however due to limited time on my end to maintain the code, as well as the lack of restream opportunities on alternate channels, this code will no longer be maintained and will be used "as is".

# ALTTPRCropDashboard

Made with the intentions of making cropping and setup of a ALTTPR Restream easier.

VERY EARLY DEVELOPMENT!  Still a big work in progress!

Currently working decently:
- Initial setup to save settings
- Save OBS/Crop settings to a local DB file
- Set Commentary/Runner names and tracker URL's to OBS
- Send the VLC video to the proper sources
- Pull source crop settings from OBS
- Set crop from pulled database

Somewhat working but needs work:
- Ability to change the OBS Websocket port to open a 2nd instance without it complaining/crashing (Works but closing OBS out of order causes issues.  Need to find a good way of minimizing issues)
- Open VLC of the stream of the player selected (works but a redesign of what we save to the DB will mean this changes as well.  Also relies on streamlink to be installed and correctly picking the directory)
- Expert mode for features to test and thus not quite ready for widespread use.  Most work well enough but possible tweaks may be needed and there may be bugs so use at own risk.

New Features working on:
- Ability to reset the local DB to nothing as there were issues with it on occasion
- Ability to do 2 or 4 runner crops as there may be a time that is needed to do 4 runners (Upcoming qualifiers/possibly another 2v2 tournament)
- Have another text field to display game mode (This may be needed in an upcoming tournament)
- Setting the timer/game window size/positions on hitting "Set Crop" to make sure everyone has the same positioning/size.  The issue is if people don't set their sources bounding box correctly as OBS Websocket doesn't have a way of setting this correctly. 

Possible features (in no specific order):
- Ability to pick which crop of a runner to use/preview other peoples crops.  If I can find a way I'm happy with to impliment this I may add it.  Until then it's just a thought.
- Add a way of selecting specific settings based off a pre-defined layout.  The idea behind this would be setting the background images and where the game/timer windows would be before the tournament starts and then being able to export those settings for restreamers to import to OBS.  From there, we would know where all the window positions would be and could have a config file that could just pull the info.  If they need to do a restream for another series where the window position is somewhere else they can just load that config and it would set things up based on that.  Currently hardcoded which is not ideal.

# Notes

I am not a major coder.  Just squeak by with what I need to do at work which is simple compared to what others do.  VB.net is what I use at work so it's what I'm familiar with.