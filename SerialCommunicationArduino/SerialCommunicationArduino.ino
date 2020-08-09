/*
 Name:		SerialCommunicationArduino.ino
 Created:	09.08.2020 14:38:50
 Author:	Kulagin
*/

// the setup function runs once when you press reset or power the board
void setup() {
    Serial.begin(9600);
}

// the loop function runs over and over again until power down or reset
void loop() {
    if(Serial.available() > 0) {
        const String str = Serial.readString();
        Serial.println(str);
    }
}