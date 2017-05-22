using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumToWord.Domain;

namespace NumToWord.Application.Tests
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass()]
    public class UnitTest1
    {
        /// <summary>
        /// Convert test.
        /// </summary>
        [TestMethod()]
        public void ConvertTest()
        {
            WordService _wordService = new WordService();

            Word input = new Word() {Number = "1" };            
            input = _wordService.Convert(input);
            Word expected = new Word() { Number = "One Dollar" };
            Assert.AreEqual(input.Number, expected.Number);

            input.Number = ".50";
            input = _wordService.Convert(input);
            expected.Number = "Fithty Cent";
            Assert.AreEqual(input.Number, expected.Number);
                           
            input.Number = "152.15";
            input = _wordService.Convert(input);
            expected.Number = "One Hundred And Fithty Two Dollar And Fithteen Cent";
            Assert.AreEqual(input.Number, expected.Number);

            input.Number = "6789.2";
            input = _wordService.Convert(input);
            expected.Number = "Six Thousand, Seven Hundred And Eighty Nine Dollar And Twenty Cent";
            Assert.AreEqual(input.Number, expected.Number);

            input.Number = "16789.2";
            input = _wordService.Convert(input);
            expected.Number = "Sixteen Thousand, Seven Hundred And Eighty Nine Dollar And Twenty Cent";
            Assert.AreEqual(input.Number, expected.Number);

            input.Number = "145789.25";
            input = _wordService.Convert(input);
            expected.Number = "One Hundred And Forty Five Thousand, Seven Hundred And Eighty Nine Dollar And Twenty Five Cent";
            Assert.AreEqual(input.Number, expected.Number);            

            input.Number = "6511000.69";
            input = _wordService.Convert(input);
            expected.Number = "Six Million, Five Hundred And Eleven Thousand Dollar And Sixty Nine Cent";
            Assert.AreEqual(input.Number, expected.Number);

            //...
            
        }
    }
}
