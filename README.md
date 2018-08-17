# LiveSplit.Crash
Memory-based autosplitter for Crash Bandicoot N. Sane Trilogy on PC.

## Features

The Crash NST autosplitter is meant to be a replacement for Thomadin's image-based load remover on PC. The tool is designed to be as easy to use as possible, in most cases requiring zero configuration whatsoever (just activate and go). Here's how it currently functions.

- The timer starts automatically when you select New Game from the title screen (**see the deficiencies section below**).
- The timer splits automatically when you finish a stage and return to a hub.
- The timer ends automatically when you finish your run (**see the deficiencies section below**).
- Loads are removed by pausing in-game time (IGT) during loading screens. Like the image-based tool, transition time before the screen is removed (meaning that you'll see your timer jump back a bit the moment the loading screen becomes visible).
- Box count and relic times can optionally be displayed within LiveSplit (**see the deficiencies section below**).

Additional notes:

- The timer doesn't split when you pause and quit a stage (although IGT is still paused).
- The timer doesn't split when you game over and reload a stage (although IGT is still paused).
- Undoing and skipping splits does not affect autosplitter functionality (so the timer will continue pausing and splitting as appropriate).

Note that since this autosplitter reads game memory during runtime, it unfortuantely can't be used for console runs. If you're running Crash on a console, keep using the image-based version.

## Installation instructions for LiveSplit
- Open LiveSplit
- Right-click and select Edit Splits
- Select Crash Bandicoot NST as the game (if it's not already)
- Click the Activate button underneath the attempt count
- If desired, click the Settings button to configure the autosplitter

If for some reason LiveSplit doesn't find the autosplitter automatically:

- Download LiveSplit.Crash.dll from the Releases section
- Move the DLL to your LiveSplit/Components folder (you should see lots of other DLL's in there)
- Open LiveSplit, then right-click and select Edit Layout
- Add the autosplitter (under the Control category)
- If desired, click Layout Settings (or double-click the newly-added component) to configure the autosplitter

## Known deficiencies

This list will be updated as additional features are added to the autosplitter.

- The timer currently auto-starts on Continue as well as New Game. When this happens, just reset your timer manually.
- The timer currently starts automatically, but doesn't end automatically. This is due to the fact that different categories have different end criteria. For the time being, make sure to split one last time manually at the end of your run.
- The tool currently assumes one split per stage (and boss). It'll likely be updated in the future with advanced settings to allow for more granular splits (such as collecting gems).
- The tool is currently designed for full runs only (starting from New Game). It'll likely be updated in the future to accomodate single-stage or single-hub practice (with automatic timing as usual).
- Displays for box count and relic times are currently disabled. They'll be re-enabled once tested and finished.
