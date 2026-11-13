# Quick Jurisdiction: Hardware-Integrated Event & State Engine

A real-time C# application that interfaces with an RFID reader and an audio-threshold gavel sensor to drive an interactive decision-making state machine.

Stamp a physical piece of paper on a physical clipboard to decide a digital 'judgement', either Guilty or Not Guilty, then hit with the gavel to deliver the judgement.

## Overview

Originally developed as an experimental interactive experience, this project demonstrates low-latency hardware-to-software communication, real-time audio signal detection, and deterministic state management in C#. Rather than relying on standard keyboard/mouse polling, the system processes asynchronous physical inputs from custom peripherals to trigger application logic and UI updates.

## Key Features

* **Hardware & Serial Communication:** Integrates a custom physical clipboard equipped with an RFID reader to read, parse, and validate unique tag IDs from physical stamps in real time.
* **Real-Time Audio Input Processing:** Monitors live microphone audio streams from a physical gavel and block, using decibel threshold detection to register discrete impact events with minimal false positives.
* **Event-Driven State Machine:** Decouples physical hardware listeners from core application logic using C# events/delegates.
* **Debouncing & Input Validation:** Implements cooldown timers and state locks to prevent duplicate triggers from sustained RFID proximity or acoustic reverberation.

## Controller Components
* 1 Arduino Microphone Module - Used to measure the gavel input as an audio spike
* 3 RFID Readers - Used to measure stamp input. One will be integrated into the back of the clipboard, the other two at the back of the ink pads. When a stamp is used on the area nearby the reader, it will register an input, which depending on the RFID reader, it may indicate a stamp refill or a chosen verdict.
* 2 RFID Tags - Integrated into the stamps, the tags are used to identify the stamp input as well as which stamp is used.

A seeduino as well as jumper cables were used to connect together the components as part of a cohesive control scheme.
## Video
[Link](https://falmouthac-my.sharepoint.com/:v:/g/personal/rl272978_falmouth_ac_uk/EUn_fkXjpXFMnzWX2WgwPeMB3gDHRmozMMPSO2_zZ3lNpQ?e=ze4yEE)

## Acknowledgements
* ### RFID Library ###
https://github.com/miguelbalboa/rfid.git
* ### Arduino & Unity Communication ###
https://youtu.be/ArgqeWpCDt8?t=476  
