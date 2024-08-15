using Dip.Page;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Dip.Test.UI
{
    [AllureNUnit]
    internal class EditPageTest: BasePageTest
    {
        [AllureOwner("Терентьева Анна")]
        [AllureName("Cоздание новой записи в дневнике.")]
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
        [AllureOwner("Терентьева Анна")]
        [AllureName("Добавление тега к заметке в дневнике.")]
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
        [AllureOwner("Терентьева Анна")]
        [AllureName("Добавление тега, который уже был ранее использован, к записи в дневнике.")]
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
        [AllureOwner("Терентьева Анна")]
        [AllureName("Загрузка изображения в новую запись с компьютера.")]
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
        [AllureOwner("Терентьева Анна")]
        [AllureName("Загрузка изображения с просторов интернета .")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "{text}", "https://russkiiyazyk.ru/wp-content/uploads/2018/06/Kartinka.jpg")]
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
        [AllureOwner("Терентьева Анна")]
        [AllureName("Заметка с использованием картинок и других редакций.")]
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "https://russian.korea.net/upload/content/image/506fac08ad3f4ad6b302659399a2c82b_20230613104829.jpg")]
        public void AddNewNotesWPictureAndTextEdit(string name, string pass, string url)
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
        [AllureOwner("Терентьева Анна")]
        [AllureName("Удаление заметки из дневника.")]
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
