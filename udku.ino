int lm35 = A1; //A1 anolog pinindeki değeri lm35 degerine tanımlıyoruz. 

void setup()
{
  Serial.begin(9600);  //Serial haberleşme açıldı.
}
void loop()
{
  int deger = analogRead(lm35); //deger degişkenini lm35den gelen degere tanımlıyoruz. 
  float voltaj = deger* (5000/1024.0); //Lm35 sıcaklık degerinin hesaplamasını yapıyoruz. 
  float sicaklik = voltaj/10.0;
  Serial.print("Sicaklik : "); //  Serial ekrana sıcaklık degeri yazdırıyoruz.
  Serial.print(sicaklik); // serial ekrana Sıcaklıgı yazdırıyoruz. 
  Serial.println(" C"); //  Serial ekrana C yazdırıyoruz.
  delay(1000); //Bu döngünün 1 sn içinde sürekli tekrar etmesini istiyoruz.                  
}
