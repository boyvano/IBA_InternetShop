using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace TestWebApplication.Models
{
    public class AppDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            var role1 = new IdentityRole { Name = "Administrator" };
            var role2 = new IdentityRole { Name = "User" };
            var role3 = new IdentityRole { Name = "Guest" };

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);


            // создаем админа
            var admin = new ApplicationUser { Email = "myakivan@gmail.com", UserName = "myakivan@gmail.com" };
            string password = "i08260716";
            var result = userManager.Create(admin, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }
            // создаем пользователя
            var user = new ApplicationUser { Email = "someuser@some.com", UserName = "someuser@some.com" };
            password = "some123";
            result = userManager.Create(user, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(user.Id, role2.Name);
            }
            // создаем гостя
            var guest = new ApplicationUser { Email = "someguest@some.com", UserName = "someguest@some.com" };
            password = "someguest123";
            result = userManager.Create(guest, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(user.Id, role3.Name);
            }
            List<Category> list_cat = new List<Category>();
            List<Product> list_prod = new List<Product>();
            list_cat.Add(new Category() { Name = "Симулятор" });
            list_cat.Add(new Category() { Name = "Шутер" });
            list_cat.Add(new Category() { Name = "РПГ" });
            list_prod.Add(new Product(){
               Name = "SimCity",
                Description = "Градостроительный симулятор снова с вами! Создайте город своей мечты",
                Category = list_cat[0],
                Price = 1499.00
            });
            list_prod.Add(new Product(){
                Name = "TITANFALL",
                Description = "Эта игра перенесет вас во вселенную, где малое противопоставляется большому, природа – индустрии, а человек – машине",
                Category = list_cat[1],
                Price = 2299.00
            });
            list_prod.Add(new Product(){
                Name = "Battlefield 4",
                Description = "Battlefield 4 – это определяющий для жанра, полный экшена боевик, известный своей разрушаемостью, равных которой нет",
                Category = list_cat[1],
                Price = 899.40
            });
            list_prod.Add(new Product(){
                Name = "The Sims 4",
                Description = "В реальности каждому человеку дано прожить лишь одну жизнь.Но с помощью The Sims 4 это ограничение можно снять! Вам решать — где, как и с кем жить, чем заниматься, чем украшать и обустраивать свой до",
                Category = list_cat[0],
                Price = 15.00
            });
            list_prod.Add(new Product(){
                Name = "Dark Souls 2",
                Description = "Продолжение знаменитого ролевого экшена вновь заставит игроков пройти через сложнейшие испытания. Dark Souls II предложит нового героя, новую историю и новый мир.Лишь одно неизменно – выжить в мрачной вселенной Dark Souls очень непросто.",
                Category = list_cat[2],
                Price = 949.00
            });
            list_prod.Add(new Product(){
                Name = "The Elder Scrolls V: Skyrim",
                Description = "После убийства короля Скайрима империя оказалась на грани катастрофы. Вокруг претендентов на престол сплотились новые союзы, и разгорелся конфликт.К тому же, как предсказывали древние свитки, в мир вернулись жестокие и беспощадные драконы.Теперь будущее Скайрима и всей империи зависит от драконорожденного — человека, в жилах которого течет кровь легендарных существ.",
                Category = list_cat[2],
                Price = 1399.00
            });
            list_prod.Add(new Product(){
                Name = "FIFA 14",
                Description = "Достоверный, красивый, эмоциональный футбол! Проверенный временем геймплей FIFA стал ещё лучше благодаря инновациям, поощряющим творческую игру в центре поля и позволяющим задавать её темп.",
                Category = list_cat[0],
                Price = 699.00
            });
            list_prod.Add(new Product(){
                Name = "Need for Speed Rivals",
                Description = "Забудьте про стандартные режимы игры. Сотрите грань между одиночным и многопользовательским режимом в постоянном соперничестве между гонщиками и полицией.Свободно войдите в мир, в котором ваши друзья уже участвуют в гонках и погонях. ",
                Category = list_cat[0],
                Price = 15.00
            });
            list_prod.Add(new Product(){
                Name = "Crysis 3",
                Description = "Действие игры разворачивается в 2047 году, а вам предстоит выступить в роли Пророка.",
                Category = list_cat[1],
                Price = 1299.00
            });
            list_prod.Add(new Product(){
                Name = "Dead Space 3",
                Description = "В Dead Space 3 Айзек Кларк и суровый солдат Джон Карвер отправляются в космическое путешествие, чтобы узнать о происхождении некроморфов.",
                Category = list_cat[1],
                Price = 499.00
            });
            var db = new ApplicationDbContext();
            db.Products.AddRange(list_prod);
            db.SaveChanges();
    base.Seed(context);
        }
    }
}