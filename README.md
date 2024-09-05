uygulamanın sql bağlantısını appsetings.json kısmından değiştirebilirsiniz. tablo oluşturma komutları :
CREATE TABLE `urunler` (
  `urunBarkod` varchar(45) NOT NULL,
  `urunIsim` varchar(45) DEFAULT NULL,
  `urunFiyat` decimal(18,2) DEFAULT NULL,
  PRIMARY KEY (`urunBarkod`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `users` (
  `Id` int NOT NULL,
  `Username` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `Rol` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

örnek uygulama çıktısı :

POST ile giriş yapma :
POST https://localhost:7205/api/Auth/login
Content-Type: application/json

{
   "username": "isim",
   "password": "sifre"
}

![image](https://github.com/user-attachments/assets/ff60e849-654c-41b7-8d07-8f43be79482d)



GET işlemi :
GET https://localhost:7205/api/urun
Authorization: Bearer TOKEN_BURAYA
Content-Type: application/json

![image](https://github.com/user-attachments/assets/a4a92c0b-4c4b-49d1-96e5-615a2e62a05a)
