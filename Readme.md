# 🚗 Rescue the Duldul - 2D Top-Down Car Parking Game

Unity kullanılarak 2D fizik ve mekaniklerle geliştirilmiş, aşamalı zorluk seviyelerine sahip üstten bakışlı (top-down) bir araba park etme simülasyonu.

🎮 **[Hemen Tarayıcıda Oyna (Unity Play)](https://play.unity.com/en/games/a160f323-d016-4b88-8547-9c9725775e5a/resque-the-duldul)**

---

## 📌 Proje Özeti
"Rescue the Duldul", oyuncunun dar sokaklarda ve dinamik engellerin olduğu parkurlarda aracını hasar almadan hedef park noktasına ulaştırmasını amaçlayan minimalist bir 2D sürüş/park oyunudur.

Oyun; seviye ilerledikçe artan zorluk dinamikleri, dinamik engeller (hareketli motosiklet gibi) ve duruma duyarlı arayüz (UI) geri bildirimleri sunar.

---

## ✨ Temel Özellikler
- **Top-Down 2D Araba Fiziği:** Hızlanma, dönüş açıları ve sürtünme dengesiyle hassas araç kontrolü.
- **Kademeli 4 Bölüm:** Basit parkurlardan hareketli engeller içeren dinamik bölümlere geçiş.
- **Dinamik Engel Sistemi:** Seviye 4'te araca doğru hareket eden motosiklet mekaniği.
- **Akıllı Çarpışma ve UI Sistemi:**
  - Duvar/bariyer çarpmalarında klasik kaza ekranı.
  - Motosiklete çarpma anında tetiklenen özel kaza ekranı.
  - Park alanı başarıyla tamamlandığında devreye giren seviye geçiş ve final tebrik paneli.
- **WebGL & Tarayıcı Desteği:** Unity Play ve web tarayıcılarında kesintisiz tam ekran deneyimi.

---

## 🎮 Kontroller

| Tuş | Eylem |
| :--- | :--- |
| **W / ↑ (Yukarı Ok)** | İleri Gaz |
| **S / ↓ (Aşağı Ok)** | Geri / Fren |
| **A / ← (Sol Ok)** | Sola Dönüş |
| **D / → (Sağ Ok)** | Sağa Dönüş |
| **F** | Tam Ekran Aç / Kapat |

---

## 🛠 Kullanılan Teknolojiler & Araçlar
- **Oyun Motoru:** Unity (2D)
- **Programlama Dili:** C#
- **Platform:** WebGL / PC
- **UI Sistemi:** Unity UI (Canvas Scaler - Responsive)
- **Fizik:** Rigidbody2D, BoxCollider2D, CompositeCollider2D

---
