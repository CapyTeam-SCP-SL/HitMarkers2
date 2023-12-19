# Configuring the plugin.

### Configs

#### Default Config
```yml
HitMarkers2:
# Whether or not the plugin is enabled.
  is_enabled: true
  # Should debug logs be enabled?
  debug: false
  # Should Welcome Message be enabled?
  is_welcome_message_enabled: true
  # Are hints globally enabled by default?
  are_hints_enabled: true
  # Should hitmarkers be displayed to SCPs?
  is_hit_maker_enabled_for_scp: true
  # Size of custom hitmarker (leave 1 for default)
  hit_marker_size: 1
  # Hint for attacker when giving damage.
  attacker_damaged_target:
  # Should a hint be displayed?
    is_enabled: true
    # Content of the Hint to be displayed.
    message: '<voffset=17em><size=20>%Damage%</size></voffset>'
    # Hint display duration.
    duration: 0.699999988
  # Hint for the attacker when killing a target.
  attacker_killed_target:
  # Should a hint be displayed?
    is_enabled: true
    # Content of the Hint to be displayed.
    message: '<voffset=15em><size=34><color=red>\U0001F480</color></size></voffset>'
    # Hint display duration.
    duration: 1
  # Warning hint for the attacker when damaging to teammate.
  warning_on_friendly_fire:
  # Should a hint be displayed?
    is_enabled: true
    # Content of the Hint to be displayed.
    message: '%DamageHint%\n<size=34><color=yellow>Warning. Try not to hurt your teammates.</color></size>'
    # Hint display duration.
    duration: 1
  # Hint for target when taking damage.
  target_took_damage:
  # Should a hint be displayed?
    is_enabled: false
    # Content of the Hint to be displayed.
    message: '<voffset=15em><size=20>you got hit by %AttackerName%</size></voffset>'
    # Hint display duration.
    duration: 0.699999988
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
| `%Damage%` | Damage dealt |
| `%DamageHint%` | Damage Hint from hint_attacker_message |
| `\n` | Makes a linebreak in the hint |
