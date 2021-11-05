using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Testavimas2;

namespace Testavimas2_Test
{
    [TestClass]
    public class GameTest
    {
        Game game = new Game("3");
        [SetUp]
        public void SetUp()
        {
            //game = new Game("3");
        }


        [TestMethod]
        public void GetTurn_false_O()
        {
            //game = new Game("3");
            game.GetTurn(false);
            NUnit.Framework.Assert.AreEqual('O', game.GetTurn(false));
        }

        [TestMethod]
        public void GetTurn_true_X()
        {
            game.GetTurn(true);
            NUnit.Framework.Assert.AreEqual('X', game.GetTurn(true));
        }

        [TestMethod]
        public void SetGridValue_0_0_C_C()
        {

            game.SetGridValue(0, 0, 'C');
            NUnit.Framework.Assert.AreEqual('C', game.GetGridValue(0, 0));
        }

        [TestMethod]
        public void IsDraw_FullMatrix_true()
        {
            char[,] test = new char[,] {
                { 'X', 'O', 'X' },
                { 'X', 'X', 'O' },
                { 'X', 'O', 'X' }};

            game.Grid = test;
            NUnit.Framework.Assert.IsTrue(game.IsDraw());
        }

        [TestMethod]
        public void IsDraw_EmptyMatrix_false()
        {
            char[,] test = new char[,] {
                { '\0', 'O', 'X' },
                { 'X', 'X', 'O' },
                { 'X', 'O', 'X' }};

            game.Grid = test;
            NUnit.Framework.Assert.IsFalse(game.IsDraw());
        }

        [TestMethod]
        public void ConsecutiveValueReached_array_X_3_true()
        {
            char[] test = new char[] {'X', 'O', 'X', 'X', 'X', 'O' };
            
            NUnit.Framework.Assert.IsTrue(game.ConsecutiveValueReached(test, 'X', 3));
        }

        [TestMethod]
        public void ConsecutiveValueReached_array_O_3_false()
        {
            char[] test = new char[] { 'X', 'O', 'X', 'X', 'X', 'O' };

            NUnit.Framework.Assert.IsFalse(game.ConsecutiveValueReached(test, 'O', 3));
        }

        [TestMethod]
        public void DimensionLength_charArray_3()
        {
            char[,] test = new char[,] { 
                { 'X', 'O', 'X' }, 
                { 'X', 'X', 'O' },
                { 'X', 'O', 'X' }};

            NUnit.Framework.Assert.AreEqual(3, game.DimensionLength(test));
        }

        [TestMethod]
        public void ExtractColumn_2dCharArray_0_3_array()
        {
            char[,] test = new char[,] {
                { 'X', 'O', 'X' },
                { 'X', 'X', 'O' },
                { 'X', 'O', 'X' }};

            char[] expected = new char[] { 'X', 'X', 'X' };

            NUnit.Framework.Assert.AreEqual(expected, game.ExtractColumn(test, 0, 3));
        }

        [TestMethod]
        public void ExtractDiagnals_2dCharArray_3_ListOfLists()
        {
            char[,] test = new char[,] {
                { 'X', 'O', 'X' },
                { 'X', 'X', 'O' },
                { 'X', 'O', 'X' }};

            List<List<char>> expected = new List<List<char>>();
            expected.Add(new List<char>() { 'X' });
            expected.Add(new List<char>() { 'X', 'O' });
            expected.Add(new List<char>() { 'X', 'X', 'X' });
            expected.Add(new List<char>() { 'O', 'O' });
            expected.Add(new List<char>() { 'X' });

            NUnit.Framework.Assert.AreEqual(expected, game.ExtractDiagnals(test, 3));
        }

        [TestMethod]
        public void RotateMatrix_charArray_3_rotatedCharArray()
        {
            char[,] test = new char[,] {
                { 'X', 'O', 'X' },
                { 'X', 'X', 'O' },
                { 'X', 'O', 'X' }};

            char[,] expected = new char[,] {
                { 'X', 'X', 'X' },
                { 'O', 'X', 'O' },
                { 'X', 'O', 'X' }};

            NUnit.Framework.Assert.AreEqual(expected, game.RotateMatrix(test, 3));
        }

        [TestMethod]
        public void GetAllArrayLines_2dCharArray_3_ListOfLists()
        {
            char[,] test = new char[,] {
                { 'X', 'O', 'X' },
                { 'X', 'X', 'O' },
                { 'X', 'O', 'X' }};

            List<List<char>> expected = new List<List<char>>();
            expected.Add(new List<char>() { 'X', 'O', 'X' });
            expected.Add(new List<char>() { 'X', 'X', 'X' });
            expected.Add(new List<char>() { 'X', 'X', 'O' });
            expected.Add(new List<char>() { 'O', 'X', 'O' });
            expected.Add(new List<char>() { 'X', 'O', 'X' });
            expected.Add(new List<char>() { 'X', 'O', 'X' });

            expected.Add(new List<char>() { 'X' });
            expected.Add(new List<char>() { 'X', 'O' });
            expected.Add(new List<char>() { 'X', 'X', 'X' });
            expected.Add(new List<char>() { 'O', 'O' });
            expected.Add(new List<char>() { 'X' });

            expected.Add(new List<char>() { 'X' });
            expected.Add(new List<char>() { 'O', 'X' });
            expected.Add(new List<char>() { 'X', 'X', 'X' });
            expected.Add(new List<char>() { 'O', 'O' });
            expected.Add(new List<char>() { 'X' });

            NUnit.Framework.Assert.AreEqual(expected, game.GetAllArrayLines(test, 3));
        }

        [TestMethod]
        public void GameWon_2dCharArray_true()
        {
            char[,] test = new char[,] {
                { 'X', 'O', 'O' },
                { 'O', 'X', 'O' },
                { 'O', 'O', 'X' }};

            game.Grid = test;
            game.XTurn = true;

            NUnit.Framework.Assert.IsTrue(game.GameWon());
        }

        [TestMethod]
        public void GameWon_2dCharArray_false()
        {
            char[,] test = new char[,] {
                { 'X', 'O', 'X' },
                { 'X', 'X', 'O' },
                { 'O', '0', 'O' }};

            game.Grid = test;
            game.XTurn = true;

            NUnit.Framework.Assert.IsFalse(game.GameWon());
        }

        [TestMethod]
        public void IsDraw_2dCharArray_true()
        {
            char[,] test = new char[,] {
                { 'X', 'O', 'X' },
                { 'X', 'X', 'O' },
                { 'O', 'X', 'O' }};

            game.Grid = test;

            NUnit.Framework.Assert.IsTrue(game.IsDraw());
        }

        [TestMethod]
        public void IsDraw_2dCharArray_false()
        {
            char[,] test = new char[,] {
                { 'X', 'O', 'X' },
                { 'X', 'X', 'O' },
                { 'O', '\0', 'O' }};

            game.Grid = test;

            NUnit.Framework.Assert.IsFalse(game.IsDraw());
        }
    }
}
