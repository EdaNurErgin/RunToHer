# RunToHer 🏃‍♂️💨

Unity 2D ile geliştirilmiş bir endless runner oyunu. Oyuncu, kız karaktere yetişmeye çalışırken arkasından gelen botlardan kaçmalı ve coin toplayarak hızını arttırmalı ve kıza yetişme şansını yakalamalıdır

## 🎮 Oyun Hakkında

**RunToHer**, hızlı refleksler ve stratejik hareket gerektiren bir platform oyunudur. Oyuncu, kız karaktere yetişmek için koşarken:
- Coin toplayarak seviye atlar
- Her seviyede hız artar
- Arkadan gelen botlardan kaçınmalıdır
- Kıza yetişirse kazanır, bota yakalanırsa kaybeder

## ✨ Özellikler

- **Dinamik Hız Sistemi**: Coin topladıkça seviye atlar ve oyun hızı artar
- **Bot AI**: Oyuncuyu takip eden akıllı bot sistemi
- **Coin Toplama**: Yol boyunca coin toplayarak puan kazanma
- **Ses Efektleri**: Zıplama, kazanma ve kaybetme sesleri
- **UI Sistemi**: Canlı coin ve seviye gösterimi
- **Game Over & Win Ekranları**: Oyun sonu ekranları
- **Kamera Takibi**: Oyuncuyu takip eden dinamik kamera

## 🛠️ Teknik Detaylar

### Unity Versiyonu
- **Unity Editor**: 6000.2.12f1

### Kullanılan Teknolojiler
- Unity 2D
- Universal Render Pipeline (URP)
- Unity Input System
- TextMesh Pro
- C# Scripting

### Ana Scriptler

- **GameManager.cs**: Oyun durumu, skor, seviye ve UI yönetimi
- **PlayerMovement.cs**: Oyuncu hareket kontrolü (koşma, zıplama)
- **GirlMovement.cs**: Kız karakterin hareketi
- **BotAI.cs**: Botların oyuncuyu takip etme AI'ı
- **Coin.cs**: Coin toplama mekaniği
- **FinishZone.cs**: Bitiş bölgesi kontrolü
- **CameraFollow.cs**: Kamera takip sistemi
- **Spawner.cs**: Nesne spawn mekanizması
- **MainMenuUI.cs**: Ana menü yönetimi

## 🎯 Nasıl Oynanır?

1. **Hareket**: 
   - `A` / `←` (Sol Ok) veya `D` / `→` (Sağ Ok) tuşları ile sağa-sola hareket
   - `Space` tuşu ile zıplama

2. **Amaç**:
   - Kız karaktere yetişmek
   - Yol boyunca coin toplamak
   - Botlardan kaçmak

3. **Kazanma/Kaybetme**:
   - ✅ Kıza yetişirsen → **KAZANDIN!**
   - ❌ Bota yakalanırsan → **OYUN BİTTİ!**

## 📁 Proje Yapısı

```
RunToHer/
├── Assets/
│   ├── Audio/              # Ses dosyaları
│   ├── Prefabs/            # Oyun prefab'ları
│   ├── Scenes/             # Unity sahneleri
│   ├── Scripts/            # C# scriptleri
│   ├── Settings/           # Oyun ayarları
│   └── Sprites/            # Görsel dosyalar
├── ProjectSettings/        # Unity proje ayarları
└── Packages/               # Unity paketleri
```

## 🚀 Kurulum

1. Unity Hub'ı açın
2. "Add" butonuna tıklayın ve proje klasörünü seçin
3. Unity Editor 6000.2.12f1 veya uyumlu bir versiyon kullanın
4. Projeyi açın ve oynamaya başlayın!

## 🎨 Geliştirme Notları

- Oyun 2D fizik motoru kullanır
- Rigidbody2D ile fizik simülasyonu yapılır
- Singleton pattern ile GameManager yönetilir
- Time.timeScale ile oyun duraklatma/kaldırma kontrolü yapılır


---

**Not**: Oyunu test etmek için Unity Editor'da Play butonuna basmanız yeterlidir. Tüm kontroller Unity Input System üzerinden yapılandırılmıştır.

