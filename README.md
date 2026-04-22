# "Quick Jurisdiction" Project Brief
## Design
* Wooden block and gavel - Hitting the gavel to the block registers an input to the game, delivering a verdict
* Guilty and Not Guilty stamps - Two stamps that can be stamped onto paper, with the last stamp used deciding whether the verdict is Guilty or Not Guilty
* Green/Red Ink pads - Used to refill the stamps with ink, both for physical use but will also register an input for a game mechanic requiring ink
* Clipboard and documents - A clipboard holding 'documents' representing each of the cases in the game. Using a stamp on a document registers the input of the stamp.
## Research
One inspiration for the experience is the game 'Papers Please', which plays similarly, approving or denying entry into a fictional country via the information provided in passports and documents, using stamps to approve or deny. I couldn't find any kind of controller replicating that physical experience, so the absence of other controllers inspired the design.
## Controller Components
* 1 Arduino Microphone Module - Used to measure the gavel input as an audio spike
* 3 RFID Readers - Used to measure stamp input. One will be integrated into the back of the clipboard, the other two at the back of the ink pads. When a stamp is used on the area nearby the reader, it will register an input, which depending on the RFID reader, it may indicate a stamp refill or a chosen verdict.
* 2 RFID Tags - Integrated into the stamps, the tags are used to identify the stamp input as well as which stamp is used.

A seeduino as well as jumper cables will also be used to connect together the components as part of a cohesive control scheme.
## Video
[Video](https://falmouthac-my.sharepoint.com/:v:/g/personal/rl272978_falmouth_ac_uk/EUn_fkXjpXFMnzWX2WgwPeMB3gDHRmozMMPSO2_zZ3lNpQ?e=ze4yEE)

## Acknowledgements
* ### RFID Library ###
I used the MFRC522 library for the RFID reader, using some of the example code. It can be found here: https://github.com/miguelbalboa/rfid.git
* ### Arduino & Unity Communication ###
I used this tutorial to help integrate the arduino inputs into unity https://youtu.be/ArgqeWpCDt8?t=476  
* ### Stamp Hilts and Plates ###
The robotics staff, Ben in particular, helped laser cut the stamp plates and 3D print the stamp hilts. I created the models however.
