/**
 *
 * HX711 library for Arduino - example file
 * https://github.com/bogde/HX711 
 *
 * MIT License
 * (c) 2018 Bogdan Necula
 *
 * Modified by Ayden Nguyen from UBC AeroDesign
 *
 * Integrates thrust measurement into an automated ESC controller for easy thrust testing
 * Uses UBC AeroDesign's existing thrust stand through USB communication
 * Once sensors are calibrated, enter serial monitor, press "b" to begin, "r" to recalibrate load cell,
   and any other character to stop test immediately. Ensure "No Line Ending" is selected next to input box (otherwise wrong characters will be detected)
   - Left column is the throttle percentage, right column is the thrust in lbs
 *
 * https://github.com/u759/UBC-AeroDesign-Thrust-Stand
 *
 *
**/
#include <HX711.h>
#include <Servo.h>

#define ESC_PIN (5)      // connected to ESC control wire
#define LED_BUILTIN (2)  // not defaulted properly for ESP32s/you must define it

Servo ESC;  // create servo object to control the ESC

int incomingByte = 0;
int i = 0;
unsigned long timepoint;


// HX711 circuit wiring
const int LOADCELL_DOUT_PIN = 3;
const int LOADCELL_SCK_PIN = 2;

HX711 scale;

void setup() {
  Serial.begin(38400);
  ESC.attach(ESC_PIN, 1000, 2000);  // (pin, min pulse width, max pulse width in microseconds)
  ESC.write(0);

  Serial.println("Welcome to the Thrust Stand!");

  Serial.println("Initializing the scale");

  // Initialize library with data output pin, clock input pin and gain factor.
  // Channel selection is made by passing the appropriate gain:
  // - With a gain factor of 64 or 128, channel A is selected
  // - With a gain factor of 32, channel B is selected
  // By omitting the gain factor parameter, the library
  // default "128" (Channel A) is used here.
  scale.begin(LOADCELL_DOUT_PIN, LOADCELL_SCK_PIN);

  Serial.println("Before setting up the scale:");
  Serial.print("read: \t\t");
  Serial.println(scale.read());  // print a raw reading from the ADC

  Serial.print("read average: \t\t");
  Serial.println(scale.read_average(20));  // print the average of 20 readings from the ADC

  Serial.print("get value: \t\t");
  Serial.println(scale.get_value(5));  // print the average of 5 readings from the ADC minus the tare weight (not set yet)

  Serial.print("get units: \t\t");
  Serial.println(scale.get_units(5), 1);  // print the average of 5 readings from the ADC minus tare weight (not set) divided
  // by the SCALE parameter (not set yet)

  scale.set_scale(2280.f);     // this value is obtained by calibrating the scale with known weights; see the README for details
  scale.tare();  // reset the scale to 0

  Serial.println("After setting up the scale:");

  Serial.print("read: \t\t");
  Serial.println(scale.read());  // print a raw reading from the ADC

  Serial.print("read average: \t\t");
  Serial.println(scale.read_average(20));  // print the average of 20 readings from the ADC

  Serial.print("get value: \t\t");
  Serial.println(scale.get_value(5));  // print the average of 5 readings from the ADC minus the tare weight, set with tare()

  Serial.print("get units: \t\t");
  Serial.println(scale.get_units(5), 1);  // print the average of 5 readings from the ADC minus tare weight, divided
  // by the SCALE parameter set with set_scale

  Serial.println("Calibration Complete! Readings:");
}

void loop() {

  if (Serial.available() > 0) {
    // read the incoming byte:
    incomingByte = Serial.read();   //reads keyboard command; b for begin (ASCII char 98), r for recalibrate (ASCII char 114), and anything else to stop the thrust stand
    if (incomingByte == 98) {
      timepoint = millis();
      incomingByte == 98;
      i = 0;
    } else if (incomingByte == 114) {
      setup();
    } else {
      incomingByte = 0;
      Serial.println("Stopping...");
      Serial.println();
    }
  }


  if (incomingByte == 98 && millis() - timepoint < 3600) {         //run thrust test for 3.6s
    int speed = 1000 + 100 + 100 * ((millis() - timepoint) / 300);   //increment throttle by 10% every 300 milliseconds
    ESC.write(speed);

    if (millis() - timepoint > 3500 && i != 1) {   //calculates thrust after propeller speed is stable

      double grams;
      double pounds;
      //grams = scale.get_units() * 0.0229308641975309;
      pounds = -scale.get_units() * 0.0229308641975309;   //calibration
      //Serial.print("\t\tThrust: ");
      Serial.print("\t");
      Serial.print(pounds, 1);
      //Serial.print(" lbf")
      //Serial.print("\t| average:\t");
      //Serial.println(scale.get_units(10), 1);
      Serial.println();

      scale.power_down();  // put the ADC in sleep mode
      scale.power_up();

      i = 1;

    }

    if(millis() - timepoint >= 3600){
      Serial.println("Done!");
      Serial.println();
    }

  } else {
    ESC.write(0);
  }
}
