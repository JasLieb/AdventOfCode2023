using FluentAssertions;

namespace AdventOfCore2023.Tests
{
    [TestClass]
    public class NumberReaderTests
    {
        private NumberReader _numberReader = new();
        
        [TestMethod]
        [TestCategory("NonLitteral")]
        public void ShouldFindOneNumberReturnsTwiceSame()
        {
            var intValuefound = _numberReader.Parse("FDGSDFJG3JFD");
            intValuefound.Should().Be(33);
        }

        [TestMethod]
        [TestCategory("NonLitteral")]
        public void ShouldFindTwoNumbersReturnsFirstAndLastConcatenation()
        {
            var intValuefound = _numberReader.Parse("FDGS1D25F5JG3JFD");
            intValuefound.Should().Be(13);
        }

        [TestMethod]
        [TestCategory("Litteral")]
        public void ShouldFindOneLitteralNumberReturnsTwiceSame()
        {
            var intValuefound = _numberReader.Parse("FDGSoneDFJGJFD");
            intValuefound.Should().Be(11);
        }

        [TestMethod]
        [TestCategory("Litteral")]
        public void ShouldFindTwoLitteralNumbersReturnsFirstAndLastConcatenation()
        {
            var intValuefound = _numberReader.Parse("FDGSoneD25F5JGthreeJFD");
            intValuefound.Should().Be(13);
        }

        [TestMethod]
        public void ShouldFindTwoAnyTypeNumbersReturnsFirstAndLastConcatenation()
        {
            var intValuefound = _numberReader.Parse("FDGSD2one5F5JGthreeJFD");
            intValuefound.Should().Be(23);

            intValuefound = _numberReader.Parse("FDGSDone5F5JGthree9JFD");
            intValuefound.Should().Be(19);
        }

        [TestMethod]
        [Ignore("Don't want to spoil")]
        public void LogicShouldGiveSumOfCalibrationNonLitteral()
        {
            var calibrationSum = 0;
            foreach(var rawCalibration in CalibrationsValues.RawCalibrationNonLitteral)
            {
                calibrationSum += _numberReader.Parse(rawCalibration);
            }
            calibrationSum.Should().Be(-1); 
        }

        [TestMethod]
        [Ignore("Don't want to spoil")]
        public void LogicShouldGiveSumOfCalibrationWithLitteral()
        {
            var calibrationSum = 0;
            foreach (var rawCalibration in CalibrationsValues.RawCalibrationLitteral)
            {
                calibrationSum += _numberReader.Parse(rawCalibration);
            }
            calibrationSum.Should().Be(-1);
        }
    }
}