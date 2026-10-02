# 🔊 Sound-Bound

![Unity](https://img.shields.io/badge/Unity-URP_2D-blue?style=for-the-badge&logo=unity)
![C#](https://img.shields.io/badge/C%23-Scripting-green?style=for-the-badge&logo=csharp)
![Developer](https://img.shields.io/badge/Developer-Enes_%C5%9Een-orange?style=for-the-badge)

**Sound-Bound**, ses dalgaları ve ekolokasyon (echolocation) mekaniğini odağına alan, 2D atmosferik bir bulmaca-keşif oyunudur. Karanlık ortamlarda yolunuzu bulmak için ses dalgaları yaymalı, engelleri aşmalı ve bölümleri tamamlamalısınız.

---

## 🎮 Oyunun Temel Mekanikleri & Özellikleri

- **Ekolokasyon & Ses Dalgaları (`F Snap`):** Karanlıkta çevrenizi göremediğiniz anlarda `F` tuşu ile şıklatma (Snap) yaparak etrafa ses dalgaları yayırsınız(urp light). Yayılan dalgalar çevredeki nesneleri ve duvarları geçici olarak görünür kılar.
- **Dinamik Aydınlatma (URP 2D):** Universal Render Pipeline (URP) kullanılarak hazırlanan ışık yönetimi sayesinde ses ve ışık etkileşimli bir atmosfer sunulur.
- **Etkileşimli Çevre Nesneleri:** çukurlardan kaçının ve sonraki seviyeye geçmek için merdivenleri kullanın.
- **Özel Karakter & Arayüz Animasyonları:** 4 yönlü oyuncu yürüme animasyonları ve özel UI buton etkileşimleri.

---

## 🕹️ Kontroller

| Tuş | Eylem |
| :--- | :--- |
| **`W` `A` `S` `D`** | Karakteri hareket ettir (Yukarı, Sol, Aşağı, Sağ) |
| **`F`** | Parmak Şıklat / Ses Dalgası Yay (Snap) |

---

## 📂 Proje Dizin Yapısı

 projenin ana klasör mimarisi aşağıda özetlenmiştir:

```text
enes-sen-sound-bound/
├── Assets/
│   ├── Animations/       # Buton, oyuncu, efekt ve ses dalgası animasyonları
│   ├── Palletes/         # Materyaller, kaplamalar (Textures) ve çevre prefab'ları
│   ├── Prefabs/          # Oyuncu, Ses Dalgası, Kutular, Merdiven ve Müzik prefab'ları
│   ├── Scenes/           # Intro, Menu, Level1 ve Level2 sahneleri
│   ├── Scripts/          # Oyun mantığını yöneten C# script'leri
│   │   ├── Managers/     # GameManager, LightManager, SceneChangeManager
│   │   └── Player/       # PlayerMovement, PlayerCollisions
│   ├── Sounds/           # Ses efektleri (snap, walk) ve atmosferik müzikler
│   └── URP/              # Universal Render Pipeline aydınlatma ve render ayarları
└── ProjectSettings/      # Unity proje ve girdi ayarları
```

---

## 🛠️ Sistem Mimarisi & Kod Yapısı

Proje modüler ve yönetilebilir bir script mimarisine sahiptir:

```
[ Presentation ]        [ World & Audio ]            [ Gameplay ]             [ Scenes ]
 ├── Animations          ├── Environment Assets       ├── Player Movement      ├── Intro.unity
 └── Menu & UI Art       ├── Light Manager            ├── Player Collisions    ├── Menu.unity
                         ├── Gameplay Prefabs         ├── Game Manager         ├── Level1.unity
                         └── Sound Assets             └── Scene Changes        └── Level2.unity
```

### Öne Çıkan Script'ler:
- **`GameManager.cs`**: Genel oyun durumunu, seviye akışını ve oyun içi olayları kontrol eder.
- **`LightManager.cs`**: URP 2D aydınlatma sistemini ve ses dalgalarının ışıkla etkileşimini yönetir.
- **`SceneChangeManager.cs`**: Sahneler arası geçişleri (Fade-in / Fade-out efektleri ile) sağlar.
- **`PlayerMovement.cs`**: 4 yönlü karakter hareketini ve animasyon parametrelerini işler.
- **`PlayerCollisions.cs`**: Karakterin kutular, çukurlar, merdivenler ve alan sınırlarıyla etkileşimini kontrol eder.

---

## 🚀 Projeyi Çalıştırma

1. Bu depoyu klonlayın veya indirin:
   ```bash
   git clone https://github.com/enes-sen/sound-bound.git
   ```
2. **Unity Hub**'ı açın ve **Add project from disk** seçeneği ile proje klasörünü seçin.
3. Uygun Unity sürümü ile projeyi başlatın (2D URP şablonu desteklenmektedir).
4. `Assets/Scenes/Menu.unity` veya `Intro.unity` sahnesini açarak oyunu **Play** butonuna basıp başlatın.

---

## 🎨 Tasarım ve Varlıklar

- **Geliştirici:** Enes Şen
- **Stüdyo / Marka:** Bear Silhouette Games
- **Grafik & Ses:** Özel pixel art kaplamalar, URP 2D aydınlatma efektleri ve atmosferik ses efektleri (`.wav`).

---
*Sound-Bound — Sesin rehberliğinde karanlığı aş.*
