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

## Notlar

- Scoped servisler için mutlaka `CreateScope()` ile bir scope oluşturulmalı ve çözümlemeler bu scope üzerinden yapılmalıdır.
- Otomatik constructor injection ile bağımlılıklarınız otomatik çözülür.

---

Bu proje, DI prensiplerini ve temel bir DI konteynerinin nasıl çalıştığını anlamak için örnek olarak hazırlanmıştır.
