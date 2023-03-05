﻿using IndianStateCensusAnalyser;
using System;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.CensusAnalyser;
using IndianStateCensusAnalyser.POCO;
using NUnit.Framework;

namespace TestIndianStatesCensusAnalyser
{


    [TestFixture]
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusfilePath = @"C:\Users\SHIVNERI\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\IndianStateCensusData.csv";
        static string wrongIndianStateCensusfilePath = @"C:\Users\SHIVNERI\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\IndianStateCensusData.txt";
        static string wrongIndianStateCensusfileType = @"C:\Users\SHIVNERI\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\IndianStateCensusData.txt";
        static string delimiterIndianCensusfilePath = @"C:\Users\SHIVNERI\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\DelimiterIndianCensusData.csv";
        static string wrongHeaderIndianCensusfilePath = @"C:\Users\SHIVNERI\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\WrongHeaderIndianSatateCensusData.csv";

        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCodefilePath = @"C:\Users\SHIVNERI\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\CSVFiles\IndianStateCode.csv";
        static string wrongIndianStateCodefilePath = @"E:\IndianStatesCensusAnalyserProblem248\IndianStatesCensusAnalyserProblem248\IndianStatesCensusAnalyserProblem\CSVFiles\IndianCode.csv";

        IndianStateCensusAnalyser.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateCensusAnalyser.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        /// <summary>
        /// TC1.1- Given indian census data file when readed should return census data count
        /// </summary>

        [TestCase]
        public void GivenIndianCensusDataFileWhenReadedShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusfilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Console.WriteLine("Total state census => {0}", totalRecord.Count);
        }

        /// <summary>
        /// TC1.2- Given state census csv file if incorrect returns a custom exception
        /// </summary>
        [Test]
        public void GivenWrongStateCensusCsvFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusfilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }

        /// <summary>
        /// TC1.3- Given state census data file when correct but type incorrect return custom exception
        /// </summary>
        [Test]
        public void GivenStateCensusDataFileWhenCorrectButTypeIncorrectCustomReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusfileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }

        /// <summary>
        /// TC1.4- Given state census data file when correct but delimiter incorrect custom return exception
        /// </summary>
        [Test]
        public void GivenStateCensusDataFileWhenCorrectButDelimiterIncorrectCustomReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCensusfilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER, censusException.eType);
        }
        /// <summary>
        /// TC1.5- Given state census data file when correct but header incorrect return custom exception
        /// </summary>
        [Test]
        public void GivenStateCensusDataFileWhenCorrectButHeaderIncorrectCustomReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusfilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }

        /// <summary>
        /// TC2.1- Given indian code data file when readed should return code data count
        /// </summary>
        [Test]
        public void GivenIndianCensusDataFileWhenReadedShouldReturnCodeDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodefilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
            Console.WriteLine("Total state code => {0}", stateRecord.Count);
        }

        /// <summary>
        /// TC2.2- Given state census csv file if incorrect returns a custom exception
        /// </summary>
        [Test]
        public void GivenWrongStateCodeCsvFile_WhenReaded_ShouldReturnCustomException()
        {
            var stateCodeException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodefilePath, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateCodeException.eType);
        }
    }
}
