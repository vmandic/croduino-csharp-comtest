//Authors: Željko Mandić and Vedran Mandić, 31.8.2014.
//Controls the LED lamps digitally on port 13
//waits for input over the connected COM port (USB)

int led = 13;

void setup() 
{
  // put your setup code here, to run once:
  Serial.begin(9600);
  pinMode(led, OUTPUT);
}

void loop() 
{
    int val = Serial.read() - 48;
    
    if (val == 1)
    {
      digitalWrite(led, HIGH);
      Serial.println("LED lamp is ON!");
    }
    else if (val == 2)
    {
      digitalWrite(led, LOW);
      Serial.println("LED lamp is OFF!");
    }
    else
    {
      Serial.println("Waiting for input...");
    }
    
    delay(500);
}
