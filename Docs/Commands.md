# Commands

| Command                              | Description                                                              |
|--------------------------------------|--------------------------------------------------------------------------|
| `disablehints ((id/name) or (all/*))`| Disables plugin hints until the end of the round/until they are enabled. |
| `enablehints ((id/name) or (all/*))` | Displays a list of plugin hints with their name, id and action           |
| `hitMarkers list`                    | Displays a list of plugin hints with their name, id and action           |

----

# Info :clipboard:
## *To see all hint IDs & Names, enter the command in the admin console:*
``hitMarkers list``
#### This command will show all hint IDs & Names.
#### The hint IDs and names can be used in other commands.

## *To disable the hint before the end of the round/until it is turned on, enter the command:*
``disablehints ((id/name) or (all/*))``
#### This command disables plugin hints until the end of the round.
#### To turn the hints back on, use the following command.

## *To enable the hint even if it is disabled in the config, enter the command:*
``enablehints ((id/name) or (all/*))``
#### This command enables hints until the end of the round, even if they are disabled in the config.