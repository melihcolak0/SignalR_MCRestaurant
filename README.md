# :rocket:ASP.NET Core API SignalR ile QR Kodlu Sipariş Yönetimi
Bu repository, Murat Yücedağ'ın Udemy'de bulunan Asp.Net Core Api SignalR ile QR Kodlu Sipariş Yönetimi kursunu içermektedir. Bu eğitimde bana yol gösteren Murat Yücedağ'a çok teşekkür ederim.

ASP.NET Core Web Application (.NET Core Framework) kullanarak dinamik bir Sipariş Yönetimi sitesi oluşturdum. Bu projede N-Tier Architecture (N Katmanlı Mimari) ve MVC tabanlı bir yapı kullandım. SOLID prensiplerine ve dosya organizasyonuna uygun şekilde geliştirme yaparak kod tekrarını en aza indirmeye çalıştım. Entity Framework Core - Code First yaklaşımını kullanarak veritabanı bağlantılarını oluşturdum. FluentValidation ile doğrulamaları gerçekleştirdim.

N-Tier Architecture (N Katmanlı Mimari), yazılım uygulamalarını birden fazla bağımsız katmana (layer) bölerek geliştirmeye olanak tanıyan bir yazılım mimari modelidir.
Bu mimari, uygulamanın farklı katmanlarını belirleyerek modülerlik, ölçeklenebilirlik ve bakım kolaylığı sağlar.

Genel anlamda 7 katman üzerinde projeyi oluşturdum. Presentation Layer (Sunum Katmanı), kullanıcının doğrudan etkileşimde bulunduğu katmandır. Burada HTML5, CSS3, Bootstrap ve JavaScript kullanarak web sayfaları oluşturdum. Business Logic Layer (İş Mantığı Katmanı), uygulamanın kurallarını ve iş mantığını barındırır. Service ve Manager olarak tüm entity'lerin metotlarını oluşturup kontrollerini yaptım. Data Access Layer (Veri Erişim Katmanı), veri tabanı ile etkileşimi sağlar. Burada veri tabanındaki verileri gereken şekilde kullandım. Entity Layer (Varlık Katmanı), verileri saklayan katmandır. Burası Code-First yaklaşımının başlangıcıdır. Veri tabanındaki tablolar ve sütunlar yerine bu katmanda sınıflar ve property'ler kullandım. Bir diğer katman da ASP.NET Web API ile servisler oluşturduğum API katmanıdır. API Controller'lar ile bu katmanda HTTP tabanlı istekleri (GET, POST, PUT, DELETE vb.) işleyerek veri alıp gönderdim. Sunum Katmanı'nda da bu oluşturduğum servisleri consume ettim. Bunun dışında CRUD işlemleri sırasında örnek olarak Fluent Validation işlemlerini uyguladım ve bu sayede daha kontrollü ve profesyonel bir yapı elde ettim. Kullanıcı'ların yönetimini Identity ve Roller ile yaptım. ASP.NET Core Identity, kimlik doğrulama (authentication) ve yetkilendirme (authorization) işlemlerini yönetmek için kullanılan bir sistemdir. Kullanıcı giriş-çıkış işlemlerini, rollerle yetkilendirmeyi ve güvenli parola yönetimini kolaylaştırır.

API katmanında anlık bilgi akışını sağlamak için de SignalR kullandım. SignalR, Microsoft'un geliştirdiği bir kütüphanedir ve .NET uygulamalarında gerçek zamanlı web fonksiyonelliği sağlar. SignalR, istemci ve sunucu arasında hızlı bir şekilde iki yönlü iletişim kurarak web uygulamaları için anlık veri iletimi sağlar. Özellikle chat uygulamaları, canlı bildirimler, sosyal medya etkileşimleri gibi senaryolarda kullanılır. SignalR, WebSocket gibi teknolojileri kullanarak istemci ile sunucu arasında sürekli bir bağlantı sağlar, ancak WebSocket desteği olmayan tarayıcılar için diğer protokoller de kullanabilir.

Özet olarak bu proje, restoran masa ve menü yönetimini dijitalleştirmek amacıyla geliştirilmiş, modern yazılım teknolojileriyle donatılmış bir web uygulamasıdır. ASP.NET Core tabanlı geliştirilen bu uygulamada, katmanlı mimari yapısı benimsenerek sürdürülebilir, test edilebilir ve ölçeklenebilir bir yazılım altyapısı oluşturulmuştur. Projede, API geliştirme ve tüketme süreçleri detaylıca ele alınmış; ASP.NET Web API ile servisler oluşturulmuş, HttpClient ile bu servisler consume edilmiştir. Gerçek zamanlı veri akışı için SignalR entegrasyonu kullanılmış, böylece kullanıcı arayüzü dinamik olarak güncellenebilir hale getirilmiştir.

Veri transferi için DTO (Data Transfer Object) katmanı kullanılmış ve AutoMapper ile katmanlar arası dönüşümler kolaylaştırılmıştır. Kullanıcı kimlik doğrulama ve yetkilendirme işlemleri için ASP.NET Identity altyapısı kullanılmış, güvenli bir kullanıcı yönetimi sağlanmıştır. Kullanıcı deneyimini artırmak adına AJAX teknolojisiyle sayfa yenilenmeden işlemler gerçekleştirilmiş, FluentValidation ile form doğrulamaları katmanlı bir şekilde yapılmıştır. Ek olarak, sipariş masalarına özel QR kod üretimi ve gönderimi gibi yenilikçi özellikler eklenmiş, kullanıcıya e-posta gönderimi için MailKit entegrasyonu sağlanmıştır. Ayrıca, dış veri kaynaklarıyla entegrasyon için RapidAPI kullanılarak farklı senaryolar test edilmiştir.

Bu proje, hem back-end hem de front-end tarafında kapsamlı teknolojileri içeren, gerçek dünya ihtiyaçlarına uygun olarak geliştirilen ve yazılım mimarisi açısından güçlü temellere sahip bir uygulamadır.

Bu projede değiştirilmesi gereken bazı noktalar olabilir fakat burada asıl amaç Back-end Development anlamında .Net Core ile admin ve vitrin panelli bir sistem kurmaktır. Front-end anlamında düzeltmeler yapılabilir. Ayrıca bu bir eğitim olduğu için tam anlamıyla bir bütünlük kurulmamıştır. Fakat bu eğitimdeki asıl amaç tüm konulardan yola çıkarak tamamen farklı temada bir proje oluşturabilmektir.

Projede genel anlamda 2 farklı bölüm bulunmaktadır;

1- Vitrin Paneli: Burada da M&C Restoranınile ilgili olarak firma hakkında bilgilerin, rezervasyon bölümünün, sipariş bölümünün, iletişim bölümünün yer aldığı paneldir.<br/>
2- Admin Paneli: Adminler'in giriş yapıp kategoriler, ürünler, rezervasyonlar, iletişim gibi alanlar ile ilgili CRUD (Create, Read, Update, Delete) işlemlerinin yaptığı paneldir.  


## :arrow_forward: Projeden Ekran Görüntüleri

### :triangular_flag_on_post: Vitrin Paneli
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_Default_Index.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_UIMenu_Index.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_UIRecipe_Index.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_UIRestaurantTable_Index.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_UIBookATable_Index.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_UIMessage_Index.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_UIBasket_Index.jpg" alt="image alt">
</div>

### :triangular_flag_on_post: Admin Paneli
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_ProgressBars_Index.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_Category_Index.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_Product_Index.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_Booking_Index.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_About_Index.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_Discount_Index.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_Slider_Index.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_Testimonial_Index.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_SocialMedia_Index.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_Contact_Index.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_Statistics_Index.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_Notification_Index.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_RestaurantTable_Index.png" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_RestaurantTable_TableListByStatus.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_QRCode_Index.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_Mail_Index.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/a9ff7b1ccd5619ef8219d91a7fd1c8c7f0b4e079/ss/localhost_7076_Setting_Index.jpg" alt="image alt">
</div>

### :triangular_flag_on_post: Kayıt, Giriş ve Hata Sayfaları
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/2c08e9be58cb9349465440a0af06bc167f1d9b25/ss2/register.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/2c08e9be58cb9349465440a0af06bc167f1d9b25/ss2/login.jpg" alt="image alt">
</div>
<div align="center">
  <img src="https://github.com/melihcolak0/SignalR_MCRestaurant/blob/2c08e9be58cb9349465440a0af06bc167f1d9b25/ss2/page404.jpg" alt="image alt">
</div>
