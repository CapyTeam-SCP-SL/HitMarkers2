# HitMarkers
### A simple plugin to show hints when attacking a player with damage numbers, and making the hitmarker larger
[![Github All Releases](https://img.shields.io/github/downloads/DentyTxR/HitMarkers/total.svg)]()


### How do I download this?
  - Go here and download the latest release, https://github.com/DentyTxR/HitMarkers/releases

### Configs

```yml
HitMarkers:
# Whether or not the plugin is enabled.
is_enabled: true
# Should debug logs be enabled?
debug: false
# Should a hint be displayed to the attacker?
enable_attacker_hint: true
# Hint message for attacker
hint_attacker_message: <voffset=17em><size=20>%Damage%</size></voffset>
# Hint duration for attacker
hint_attacker_duration: 0.7
# Should a hint be displayed to the target?
enable_target_hint: false
# Hint message for target
hint_target_message: <voffset=15em><size=20>you got hit by %AttackerName%</size></voffset>
# Hint duration for target
hint_target_duration: 0.7
# Should a hint be displayed to the attacker when they kill a player?
enable_kill_hint: true
# Hint message for kill
kill_hint_message: <voffset=15em><size=34><color=red>\U0001F480</color></size></voffset>
# Hint duration for kill message
kill_hint_duration: 1
# Should hitmarkers be displayed to SCPs?
enable_scp_hints: true
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