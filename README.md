# SimpleDI

## Servisler

- `IMessageService`: Bildirim gönderme arayüzü.
- `EmailService`: IMessageService'in e-posta ileten implementasyonu.
- `Logger`: Basit loglama servisi.
- `Notifier`: IMessageService ve Logger bağımlılıklarıyla çalışan bildirim sınıfı.

## Dosya Yapısı

- `DI/Container.cs`: Temel DI konteyneri.
- `DI/ScopedContainer.cs`: Scoped yaşam döngüsü yönetimi.
- `DI/ServiceDescriptor.cs`: Servis kayıt bilgisi.
- `DI/LifeTime.cs`: Kategori listesi.

## Notlar

- Scoped servisler için mutlaka `CreateScope()` ile bir scope oluşturulmalı ve çözümlemeler bu scope üzerinden yapılmalıdır.
- Otomatik constructor injection ile bağımlılıklarınız otomatik çözülür.


Bu proje, DI prensiplerini ve temel bir DI konteynerinin nasıl çalıştığını anlamak için örnek olarak hazırlanmıştır.

---

## SimpleDI: Basit Bir Bağımlılık Enjeksiyon Sistemi

## Lifetime.cs
Bu dosya, bir servisin ne kadar süreyle yaşayacağını belirleyen basit bir kategori listesi içerir:

- Transient: Her istendiğinde yeni bir kopya oluşturulur
- Singleton: Tüm uygulama boyunca sadece bir kez oluşturulur ve hep aynı kopya kullanılır
- Scoped: Belirli bir işlem grubu (scope) süresince aynı kopya kullanılır

## ServiceDescriptor.cs
Bu dosya, bir servisin "kimlik kartı" gibidir. İçinde şu bilgiler saklanır:

- Servisin tipi (hangi arabirim olduğu)
- Gerçekte çalışacak kod (servisin somut sınıfı)
- Yaşam süresi (yukarıdaki Lifetime seçeneklerinden biri)
- Singleton servisleri için oluşturulan tek kopyanın kendisi

## Container.cs
Bu dosya, tüm bağımlılık sisteminin kalbidir:

- Servis kayıtlarını tutar (hangi arabirim için hangi somut sınıf kullanılacak)
- Servisleri yaşam süresine göre oluşturur:

   - Singleton ise bir kez oluşturup saklar
   - Transient ise her seferinde yenisini oluşturur


- Bir sınıfa gerekli tüm bağımlılıkları otomatik olarak bulup gönderir
- Scope adı verilen bir "işlem grubu" oluşturabilir

Nasıl çalıştığını basitçe anlatmak gerekirse: Bir sınıfın (örneğin Notifier) ihtiyaç duyduğu tüm bağımlılıkları (Logger, IMessageService gibi) otomatik olarak bulup, o sınıfa gönderir. Bunu yaparken sınıfların constructor (yapıcı) metodlarına bakıp, "Bu sınıf hangi diğer sınıflara ihtiyaç duyuyor?" sorusunu sorar ve cevabına göre o sınıfları da hazırlayıp gönderir.
## ScopedContainer.cs
Bu dosya, belli bir işlem grubu (scope) için özel bir konteynerdir:

- Scope içinde oluşturulması gereken servisleri yönetir
- Ana konteynerdeki Singleton servisleri kullanmaya devam eder
- Scope içinde Scoped servislerin tek bir kopyasını tutar
- Transient servisleri her seferinde yeniden oluşturur

Bu bileşenler bir araya geldiğinde, uygulamanızdaki sınıfların birbirine doğrudan bağımlı olması yerine, bu "Container" aracılığıyla ihtiyaç duydukları şeylere erişmesini sağlar. Böylece kodunuz daha esnek, test edilebilir ve bakımı kolay hale gelir.
