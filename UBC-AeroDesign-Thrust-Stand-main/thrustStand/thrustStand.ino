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
#include <Wire.h>
#include <Adafruit_ADS1X15.h>

#define ESC_PIN (5)      // connected to ESC control wire
#define LED_BUILTIN (2)  // not defaulted properly for ESP32s/you must define it

Servo ESC;  // create servo object to control the ESC
Adafruit_ADS1115 ADS;  // create ads object to read the shunt resistor

String receivedData = "";
int i = 0;
unsigned long lastWrite;
boolean responded = true;

int throttle;

// added code for GUI
String data;
char d1;


// HX711 circuit wiring
const int LOADCELL_DOUT_PIN = 3;
const int LOADCELL_SCK_PIN = 2;

const float shuntResistance = 0.00025;

HX711 scale;

void setup() {
  Serial.begin(38400);

  Wire.begin();

  pinMode(13, OUTPUT);

  // Initialize library with data output pin, clock input pin and gain factor.
  // Channel selection is made by passing the appropriate gain:
  // - With a gain factor of 64 or 128, channel A is selected
  // - With a gain factor of 32, channel B is selected
  // By omitting the gain factor parameter, the library
  // default "128" (Channel A) is used here.
  scale.begin(LOADCELL_DOUT_PIN, LOADCELL_SCK_PIN);
}

void loop() {
  if (Serial.available() > 0) {
    // read the incoming byte:
    receivedData = Serial.readStringUntil('\n');
    receivedData.trim();
    // R for reset
    if (receivedData == "R") {
      startESC();
      callibrate();
      //activateShuntResistor();
    } else if (receivedData == "E") { // E for end
      digitalWrite(13, LOW);
      throttle = 0;
      setThrottle();
    } else {
      int receivedThrottle = receivedData.toInt();
      if (receivedThrottle >= 1 || receivedThrottle <= 100) {
        throttle = receivedThrottle;
        setThrottle();
        lastWrite = millis();
        responded = false;
      }
    }
  }

  // if throttle is not 0 and if 30 second timeout has not been reached
  if (throttle >= 0 && lastWrite + 30000 > millis()) {
    // waits one second after the esc write to return thrust information
    if ((lastWrite - millis()) / 1000 > 1 && !responded) {
      double grams;
      grams = scale.get_units() * 0.0229308641975309;
      //Serial.println(grams);
      responded = true;

      // Read differential voltage (e.g., between AIN0 and AIN1)
      //int16_t adcValue = ADS.readADC_Differential_0_1();

      // Convert ADC value to voltage (based on gain and resolution)
      //float voltage = adcValue * (4.096 / 32768.0); // ±4.096V range, 16-bit resolution

      // Calculate current using Ohm's Law
      //float current = voltage / shuntResistance;

      //Serial.println("Thrust: " + String(grams) + " Current: " + String(current));
      Serial.println("Thrust: " + String(grams));
    }
  } else {
    ESC.writeMicroseconds(1000);
  }
}

void setThrottle() {
  Serial.println("Writing throttle: " + String(throttle));
  ESC.writeMicroseconds(map(throttle, 0, 100, 1180, 2000));
}

void startESC() {
  ESC.attach(ESC_PIN, 1000, 2000);  // (pin, min pulse width, max pulse width in microseconds)
  ESC.write(0);

  Serial.println("Welcome to the Thrust Stand!");
}

void activateShuntResistor() {
  Serial.println("Initializing shunt resistor");
  if (!ADS.begin()) {
    Serial.println("Failed to initialize shunt resistor readings");
  }
  Serial.println("Communication begin");
  ADS.setGain(GAIN_ONE);
  Serial.println("Shunt resistor initialized");
}

void callibrate() {
  Serial.println("Callibrating the scale");

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

  Serial.println("Calibration Complete!");
}
