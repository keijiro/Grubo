Grubo
=====

![gif1](https://i.imgur.com/q76arws.gif)
![gif2](https://i.imgur.com/5QMdeth.gif)

**Grubo** is an experimental project that aims to present an audio-visual
experience using [Roland Groovebox MC-101] and the [Unity game engine].

[Roland Groovebox MC-101]: https://www.roland.com/us/products/mc-101/
[Unity game engine]: https://unity3d.com

System requirements
-------------------

- Unity 2019.3
- [HDRP] compatible desktop system

[HDRP]: https://unity.com/srp/High-Definition-Render-Pipeline

How to use
----------

Grubo uses a MIDI connection to control visual effects from MC-101. You can use
a physical MIDI connection (MIDI interface + MIDI cable) or a USB cable
connection with the [MC-101 MIDI driver] (only available for Windows and
macOS).

[MC-101 MIDI driver]: https://www.roland.com/us/products/mc-101/downloads/

You have to enable MIDI message transmission (`TxUSB MIDI`/`TxMIDI Out`) on all
four tracks. These options are available from the track settings menu (press
`SHIFT` and `TRACK SEL` `1` - `4`). Please see the reference manual for
details.

The visualizer is designed under the assumption that each track is assigned as
follows:

| Track   | Type    | Visual Effects    |
| ------- | ------- | ----------------- |
| Track 1 | Drums 1 | Structure effects |
| Track 2 | Drums 2 | Camera effects    |
| Track 3 | Synth 1 | Ribbons 1         |
| Track 4 | Synth 2 | Ribbons 2         |

There are a few key controls. All the visual effects are disabled by default,
so at least you have to enable one of these effects by pressing `1` - `5`.

| Key | Function                         |
| --- | -------------------------------- |
| 1   | Toggle track 1 effects           |
| 2   | Toggle track 2 primary effects   |
| 3   | Toggle track 3 effects           |
| 4   | Toggle track 4 effects           |
| 5   | Toggle track 2 secondary effects |
| q   | Color scheme 1                   |
| w   | Color scheme 2                   |
| e   | Color scheme 3                   |
| r   | Color scheme 4                   |
| t   | Randomize color scheme           |
| a   | Toggle hue shifter               |
| z   | Toggle invertion effect          |

Related projects
----------------

- Grubo uses the [Minis] plugin that allows Unity to receive MIDI messages via
  the new Unity input system.
- The [Kino] post processing effects are used to create its lo-fi visual style. 
- All the visual elements are rendered with [Visual Effect Graph].

[Minis]: https://github.com/keijiro/Minis
[Kino]: https://github.com/keijiro/Kino
[Visual Effect Graph]: https://unity.com/visual-effect-graph
