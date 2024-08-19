using Dip.Page;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace Dip.Test.UI
{
    [AllureNUnit]
    internal class EditPageTest: BasePageTest
    {
 
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "{text}")]
        [AllureName("Cоздание новой записи в дневнике.")]
        [AllureOwner("Терентьева Анна")]
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
      
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "{text}", "{new_tag}")]
        [AllureName("Добавление тега к заметке в дневнике.")]
        [AllureOwner("Терентьева Анна")]

        public void TestAddNewTags(string name, string pass, string text, string new_tag)
        {
            text = "Добавляем новый тег";
            new_tag = "2";
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.NewNotesFromDiaryClick();
            Assert.IsTrue(EditPage.IsPageOpen());
            EditPage.EditNotes(text);
            EditPage.AddTag(new_tag);
            Assert.That(new_tag, Is.EqualTo(EditPage.AssignedTags()));
        }
      
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "{text}", "{new_tag}")]
        [AllureName("Добавление тега, который уже был ранее использован, к записи в дневнике.")]
        [AllureOwner("Терентьева Анна")]
        public void TestFindTegsWhichAlreadyExist(string name, string pass, string text, string new_tag)
        {
            text = "Поиск";
            new_tag = "2";
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.NewNotesFromDiaryClick();
            Assert.IsTrue(EditPage.IsPageOpen());
            EditPage.EditNotes(text);
            EditPage.SelectByName(new_tag);
            EditPage.ClickFindTag();
            Assert.That(new_tag, Is.EqualTo(EditPage.AssignedTags()));
        }
       
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "{text}")]
        [AllureName("Загрузка изображения в новую запись с компьютера.")]
        [AllureOwner("Терентьева Анна")]
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
        [AllureName("Загрузка изображения с просторов интернета .")]
        [AllureOwner("Терентьева Анна")]
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
      
        [TestCase("terenteva1999@yandex.ru", "123456Ana", "https://russian.korea.net/upload/content/image/506fac08ad3f4ad6b302659399a2c82b_20230613104829.jpg")]
        [AllureName("Заметка с использованием картинок и других редакций.")]
        [AllureOwner("Терентьева Анна")]
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
      
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [AllureName("Удаление заметки из дневника.")]
        [AllureOwner("Терентьева Анна")]
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
      
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [AllureName("Редактирование текстовой заметки из дневника.")]
        [AllureOwner("Терентьева Анна")]
        [Description("Здесь происходит изменение текста в редакторе: жирный, курсив, подчеркнутый. ")]
        public void EditNotesText(string name, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.NewNotesFromDiaryClick();
            Assert.IsTrue(EditPage.IsPageOpen());
            EditPage.EditNotes("Тут должен быть ");
            EditPage.ClickBold();
            EditPage.EditNotes("текст, а затем ");
            EditPage.ClickItalic();
            EditPage.EditNotes("курсивный текст, а потом еще добавить вот такой: ");
            EditPage.ClickUnderline();
            EditPage.EditNotes("подчеркнутый!");
            EditPage.BackHome();
            Assert.IsTrue(EditPage.IsPageOpen());
        }
      
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [AllureName("Редактирование текстовой заметки из дневника.")]
        [AllureOwner("Терентьева Анна")]
        [Description("Здесь происходит изменение текста в редакторе: жирный, курсив, подчеркнутый. ")]
        public void EditNotesTextWithListed(string name, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.NewNotesFromDiaryClick();
            Assert.IsTrue(EditPage.IsPageOpen());
            EditPage.EditNotes("Создаем нумерованный список:");
            EditPage.AddNewLine();
            EditPage.ClickNumberList();
            EditPage.EditNotes("First line");
            EditPage.AddNewLine();
            EditPage.EditNotes("Second line");
            EditPage.AddNewLine();
            EditPage.EditNotes("Third line");
            EditPage.ClickDecreaseList();
            EditPage.EditNotes("\nТеперь создаем маркированный список: ");
            EditPage.AddNewLine();
            EditPage.ClickBulletList();
            EditPage.EditNotes("First line");
            EditPage.AddNewLine();
            EditPage.EditNotes("Second line");
            EditPage.AddNewLine();
            EditPage.EditNotes("Third line");
            EditPage.ClickDecreaseList();
            EditPage.BackHome();
            Assert.IsTrue(EditPage.IsPageOpen());
        }
      
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [AllureName("Редактирование текстовой заметки из дневника.")]
        [AllureOwner("Терентьева Анна")]
        [Description("Здесь происходит изменение текста в редакторе: жирный, курсив, подчеркнутый. ")]
        public void EmodjiTesting(string name, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            DiaryPage.NewNotesFromDiaryClick();
            Assert.IsTrue(EditPage.IsPageOpen());
            EditPage.EditNotes("Смайликииии : ");
            EditPage.AddNewLine();
            EditPage.ExpandClick();
            EditPage.SmileyOpen();
            EditPage.InsertEmodji();
            EditPage.Save();
            Assert.IsTrue(EditPage.IsPageOpen());
        }
   
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [AllureName("Удаление всех записей в дневнике.")]
        [AllureOwner("Терентьева Анна")]
        public void AllNotesDelete(string name, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            Assert.IsTrue(DiaryPage.IsPageOpen());
            DiaryPage.CLickChecbox();
            Assert.IsTrue(DiaryPage.EnabledDeleteButton());
            DiaryPage.ClickDeleteAllNotes();
            Assert.IsTrue(DiaryPage.IsPageOpen());         
        }
        
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [AllureName("Вывод на печать все заметки из дневника.")]
        [AllureOwner("Терентьева Анна")]
        public void PrinterAllNotes(string name, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            Assert.IsTrue(DiaryPage.IsPageOpen());
            DiaryPage.CLickChecbox();
            Assert.IsTrue(DiaryPage.EnabledPrinter());
            Assert.That(DiaryPage.PrinterAllNotes(), Is.EqualTo("https://monkkee.com/print_template"));
           }
        
        [TestCase("terenteva1999@yandex.ru", "123456Ana")]
        [AllureName("Вывод на печать одну заметку из дневника.")]
        [AllureOwner("Терентьева Анна")]
        public void PrinterOneNotes(string name, string pass)
        {
            LoginPage.Open();
            LoginPage.Login(name, pass);
            Assert.IsTrue(DiaryPage.IsPageOpen());
            DiaryPage.CLickChecbox();
            Assert.IsTrue(DiaryPage.EnabledPrinter());
            Assert.That(DiaryPage.PrinterOneNotes(), Is.EqualTo("https://monkkee.com/print_template"));
           }

    }
}
