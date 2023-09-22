[![HitMarkers 2](https://media.discordapp.net/attachments/1081923284133752903/1152937925223387256/unknown.png)](https://github.com/TranquilityStudio/HitMarkers2)
[![Discord](https://img.shields.io/discord/1143547375546290249?style=for-the-badge&label=DISCORD&color=blue)](https://discord.gg/ETPEH9Ahma)
[![Downloads](https://img.shields.io/github/downloads/CapyTeam-SCP-SL/HitMarkers2/total?style=for-the-badge&label=DOWNLOADS&color=00b300)](https://github.com/CapyTeam-SCP-SL/HitMarkers2/releases/)
[![Version](https://img.shields.io/github/v/tag/CapyTeam-SCP-SL/HitMarkers2?style=for-the-badge&label=VERSION&color=ff4f00)](https://github.com/CapyTeam-SCP-SL/HitMarkers2/releases/tag/2.0.0)

# HitMarkers 2
### HitMarkers 2 is simple plugin to show hints when attacking a player with damage numbers, and making the hitmarker larger

# Features
- Hints when attacking a player with damage numbers.
- Friendly fire warning.
- Making the hitmarker larger.
- Displays the number of rounds (To be added in version 2.2.0)
- Convenient in-game settings commands. (To be added in version 2.1.1)
- Setting up hitmarkers (To be added in version 2.3.0).

# Configuring the plugin.

### Configs

```yml
HitMarkers2:
# Whether or not the plugin is enabled.
  is_enabled: true
  # Should debug logs be enabled?
  debug: false
  # Should Welcome Message be enabled?
  enable_welcome_message: true
  # Should a hint be displayed to the attacker?
  enable_attacker_hint: true
  # Hint message for attacker
  hint_attacker_message: '<voffset=17em><size=20>%Damage%</size></voffset>'
  # Hint duration for attacker
  hint_attacker_duration: 0.699999988
  # Should a hint be displayed to the target?
  enable_target_hint: false
  # Hint message for target
  hint_target_message: '<voffset=15em><size=20>you got hit by %AttackerName%</size></voffset>'
  # Hint duration for target
  hint_target_duration: 0.699999988
  # Should a hint be displayed to the attacker when they kill a player?
  enable_kill_hint: true
  # Hint message for kill
  kill_hint_message: '<voffset=15em><size=34><color=red>\U0001F480</color></size></voffset>'
  # Hint duration for kill message
  kill_hint_duration: 1
  # Should hitmarkers be displayed to SCPs?
  enable_scp_hints: true
  # Should Friendly Fire Warning be displayed?
  enable_friendly_fire_warning: true
  # Hint message for Friendly Fire Warning
  friendly_fire_warning_message: '%DamageHint%\n<size=34><color=yellow>Warning. Try not to hurt your teammates.</color></size>'
  # Hint duration for Friendly Fire Warning message
  friendly_fire_warning_hint_duration: 1
  # Size of custom hitmarker (leave 1 for default)
  hit_marker_size: 1
```

\U0001F480 = skull emoji

### Custom variables
#### These can be used in the config to return info, These are case sensitive

These are for `hint_attacker_message` config
| Variable Name | Returns |
| --- | --- |
| `%TargetName%` | Target username |
| `%TargetRole%` | Target role |
| `%Damage%` | Damage delt |
| `\n` | Makes a linebreak in the hint |


These are for `hint_target_message` config
| Variable Name | Returns |
| --- | --- |
| `%AttackerName%` | Attacker username |
| `%AttackerRole%` | Attacker role |
| `%Damage%` | Damage delt |
| `\n` | Makes a linebreak in the hint |

These are for `friendly_fire_warning_message` config
| Variable Name | Returns |
| --- | --- |
| `%AttackerName%` | Attacker username |
| `%AttackerRole%` | Attacker role |
| `%Damage%` | Damage delt |
| `%DamageHint%` | Damage Hint from hint_attacker_message |
| `\n` | Makes a linebreak in the hint |


# Credits
- Plugin made by Sakred_
- Original HitMarkers plugin by [DentyTxR](https://github.com/DentyTxR)
- Special thanks to 1kRoSik (1krosik), MutVARD (motvard), BOB [C-D] (bob_ik140) for participating in testing updates.
