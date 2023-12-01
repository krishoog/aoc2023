namespace Day01.Tests
{
    public class CalibrationValueExtractorTest
    {
        [Test]
        public void Test1()
        {
            var x = new CalibrationValueExtractor();
            Assert.That(x.ParseLine("1abc2"), Is.EqualTo(12));
        }

        [Test]
        public void Test2()
        {
            var x = new CalibrationValueExtractor();
            Assert.That(x.ParseLine("pqr3stu8vwx"), Is.EqualTo(38));
        }

        [Test]
        public void Test3()
        {
            var x = new CalibrationValueExtractor();
            Assert.That(x.ParseLine("a1b2c3d4e5f"), Is.EqualTo(15));
        }

        [Test]
        public void Test4()
        {
            var x = new CalibrationValueExtractor();
            Assert.That(x.ParseLine("treb7uchet"), Is.EqualTo(77));
        }
    }
}
