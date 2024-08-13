using Dip.Page;
using Allure.NUnit.Attributes;
using Allure.NUnit;

namespace Dip.Test.UI
{
    [TestFixture]
    [AllureNUnit]
    internal class EditPageTest: BasePageTest
    {
        [AllureName("Добавление новой записи в дневник.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "{text}")]
        public void TestAddNewNotes(string name, string pass, string text)
        {
            text = "Hello World";
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.NewNotesFromDiaryClick();
            Assert.IsTrue(EditPage.IsPageOpen());
            EditPage.EditNotes(text);
            EditPage.AddNewLine();
            EditPage.BackHome();
            Assert.IsTrue(DiaryPage.IsPageOpen());      
        }
        [AllureName("Добавление нового тега к записи в дневнике.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "{text}", "{new_tag}")]

        public void TestAddNewTags(string name, string pass, string text, string new_tag)
        {
            text = "Добавляем новый тег";
            new_tag = "895";
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.NewNotesFromDiaryClick();
            Assert.IsTrue(EditPage.IsPageOpen());
            EditPage.EditNotes(text);
            EditPage.AddTag(new_tag);
            Assert.That(new_tag, Is.EqualTo(EditPage.AssignedTags()));
        }

        [AllureName("Поиск тега, который уже был использован в дневнике.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "{text}", "{new_tag}")]
        public void TestFindTegsWhichAlreadyExist(string name, string pass, string text, string new_tag)
        {
            text = "Поиск";
            new_tag = "78";
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.NewNotesFromDiaryClick();
            Assert.IsTrue(EditPage.IsPageOpen());
            EditPage.EditNotes(text);
            EditPage.SelectByName(new_tag);
            EditPage.ClickFindTag();
            Assert.That(new_tag, Is.EqualTo(EditPage.AssignedTags()));
        }
        [AllureName("Поиск несуществующего тега в дневнике.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "{text}", "{new_tag}")]
        public void TestFindTegsDoesntExist(string name, string pass, string text, string new_tag)
        {
            text = "Поиск";
            new_tag = "444444444";
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.NewNotesFromDiaryClick();
            Assert.IsTrue(EditPage.IsPageOpen());
            EditPage.EditNotes(text);
            EditPage.SelectByName(new_tag);
        }
        [AllureName("Загрузка изображения из проекта.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "{text}")]
        public void TestLoadingPictureDesktop(string name, string pass, string text)
        {
            text = "Добавили изображение с компьютера.";
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.NewNotesFromDiaryClick();
            Assert.IsTrue(EditPage.IsPageOpen());
            EditPage.EditNotes(text);
            EditPage.AddNewLine();
            EditPage.GetPictureFileDesktop("C:\\Users\\teren\\source\\repos\\Dip\\Dip\\Files\\WhatsApp_Image_2022-07-13_at_23.31.04__3_.jpeg_-_Средство_просмотра_фотографий_Wiows.png");
            EditPage.EditNotes(text);
            EditPage.Save();
            Assert.IsTrue(EditPage.IsPageOpen());
        }
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "{text}", "https://russkiiyazyk.ru/wp-content/uploads/2018/06/Kartinka.jpg")]
        [AllureName("Загрузка изображения в запись из Интернета.")]
        public void TestLoadingPictureURL(string name, string pass, string text, string url)
        {
            text = "Загружаем картинку из интернета";
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.NewNotesFromDiaryClick();
            Assert.IsTrue(EditPage.IsPageOpen());
            EditPage.EditNotes(text);
            EditPage.AddNewLine();
            EditPage.GetPictureFileURL(url);
            EditPage.Save();

        }

        [AllureName("Добавление новой записи в дневник.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "https://russian.korea.net/upload/content/image/506fac08ad3f4ad6b302659399a2c82b_20230613104829.jpg")]
        public void AddNewNptesWPictureAndTextEdit(string name, string pass, string url)
        {
            string text = "Добавление изображения из интернета";
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.NewNotesFromDiaryClick();
            Assert.IsTrue(EditPage.IsPageOpen());
            EditPage.EditNotes(text);
            EditPage.AddNewLine();
            EditPage.EditNotes("Надо добавить что-то еще.. Добавлю фото!");
            EditPage.GetPictureFileURL(url);
            EditPage.Save();
            EditPage.AddNewLine();
            Assert.IsTrue(EditPage.IsPageOpen());
        }
        [AllureName("Удаление записи из дневника.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        public void DeleteNotes(string name, string pass)
        {
            string text = "Думаю добавить картинку из интернета";
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.NewNotesFromDiaryClick();
            Assert.IsTrue(EditPage.IsPageOpen());
            EditPage.EditNotes(text);
            EditPage.DeleteNotes();
            Assert.IsTrue(EditPage.IsPageOpen());
        }
    }
}
