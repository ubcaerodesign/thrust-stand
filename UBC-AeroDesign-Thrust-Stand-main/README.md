Integrates thrust measurement into an automated ESC controller for easy thrust testing. Uses UBC AeroDesign's existing thrust stand through USB communication. Once sensors are calibrated, enter the serial monitor, press "b" to begin, "r" to recalibrate the load cell, and any other character to stop the test immediately. Ensure "No Line Ending" is selected next to the input box (otherwise wrong characters will be detected). The left column is the throttle percentage, right column is the thrust in lbs.

Steps:
- Power ESC and plug in Arduino to computer's USB port
- Open serial monitor at 38400 baud
- Wait for the sensor to calibrate
- Set serial input to "No Line Ending"
- Enter "b" to begin test, "r" to recalibrate, or any other character to STOP test immediately
- Copy readings to spreadsheet for analysis
- The left column is the throttle percentage, right column is the thrust in lbs.
