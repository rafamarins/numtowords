using System.Linq;
using NumToWord.Domain;
using NumToWord.Infrastructure.Base;

namespace NumToWord.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class WordRep : Repository<Word>
    {
        /// <summary>
        /// Converts the number.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public override Word ConvertNumber(Word entity)
        {
            Word result = new Word();

            string[] splitNum = breakWord(entity.Number);

            string rightComma = splitNum.Length > 1 ? getWord(splitNum[1], 0) : null;
            string leftComma = getWord(splitNum[0], 1);

            if (leftComma != null)
            {
                if (leftComma.Length > 0)
                    leftComma += NumberScales.CURRENCYBIG;
            }

            if (rightComma != null)
            {
                if (leftComma.Length > 0)
                    leftComma += NumberScales.SPACE + NumberScales.BIND;
                rightComma += NumberScales.CURRENCYSMALL;
            }

            result.Number = leftComma + rightComma;

            return result;
        }

        /// <summary>
        /// Gets the word.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="numType">Type of the number.</param>
        /// <returns></returns>
        private string getWord(string number, int numType)
        {
            string result = string.Empty;

            if (numType == 0)
            {
                string first = number.Substring(0, 1);

                string second = number.Length > 1 ? number.Substring(1, 1) : "0";

                return result = forRight(number, first, second);
            }
            else
            {
                int count = number.Length;
                return result = forLeft(ref count, number);
            }
        }

        /// <summary>
        /// Fors the left.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        private static string forLeft(ref int count, string number)
        {
            string[] numSplit;

            switch (count)
            {
                case 1:
                    return NumberScales.UNITS.Find(s => s.Key == parseNum(number)).Value + NumberScales.SPACE;
                case 2:
                    numSplit = fillArray(number);
                    return forRight(number, numSplit[0], numSplit[1]);
                default:
                    numSplit = fillArray(number);
                    return more(ref count, number, ref numSplit);
            }
        }

        /// <summary>
        /// Mores the specified count.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="number">The number.</param>
        /// <param name="numSplit">The number split.</param>
        /// <returns></returns>
        private static string more(ref int count, string number, ref string[] numSplit)
        {
            string result = string.Empty;

            int cc = count;

            return getResult(ref count, ref numSplit, ref result);


        }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="numSplit">The number split.</param>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        private static string getResult(ref int count, ref string[] numSplit, ref string result)
        {
            int cc = count;
            int[] resType = null;
            for (int i = 0; i < cc; i++)
            {
                resType = getResType(count);

                result = forMore(ref count, ref numSplit, result, resType);

                if (count == 2)
                    return result = forUnits(numSplit, result);
            }

            return string.Empty;
        }

        /// <summary>
        /// Fors the more.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="numSplit">The number split.</param>
        /// <param name="result">The result.</param>
        /// <param name="resType">Type of the resource.</param>
        /// <returns></returns>
        private static string forMore(ref int count, ref string[] numSplit, string result, int[] resType)
        {
            int cc = count;

            if (parseNum(numSplit[0]) > 0)
            {
                switch (resType[0])
                {
                    case 0:
                        result += forRight(string.Empty, "0", numSplit[0]);
                        result += NumberScales.MORE.Find(s => s.Key == cc).Value;

                        numSplit = removeNum(numSplit);
                        count--;
                        result += (count >= 3 && numSplit.TakeWhile(s => s != "0").Count() > 0 ? NumberScales.SEPARATOR.ToString() + NumberScales.SPACE.ToString() : NumberScales.SPACE.ToString());
                        cc = count;
                        break;
                    case 1:
                        result += forRight(string.Empty, "0", numSplit[0]);
                        result += NumberScales.MORE.Find(s => s.Key == cc / resType[1]).Value + NumberScales.SPACE + (numSplit.TakeWhile(s => s != "0").Count() > 0 ? NumberScales.BIND : string.Empty);

                        if (numSplit[1] == "0" && numSplit[2] == "0")
                        {
                            result += NumberScales.MORE.Find(s => s.Key == cc - 2).Value;
                        }

                        count--;
                        numSplit = removeNum(numSplit);
                        break;
                    default:
                        result += forRight(numSplit[0] + numSplit[1], numSplit[0], numSplit[1]);
                        result += NumberScales.MORE.Find(s => s.Key == cc - 1).Value;

                        numSplit = removeNum(removeNum(numSplit));
                        count -= 2;

                        result += (count >= 3 && numSplit.TakeWhile(s => s != "0").Count() > 0 ? NumberScales.SEPARATOR.ToString() + NumberScales.SPACE.ToString() : NumberScales.SPACE.ToString());
                        break;
                }
            }
            else
            {
                count--;
                numSplit = removeNum(numSplit);
            }

            return result;
        }

        /// <summary>
        /// Gets the type of the resource.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        private static int[] getResType(int count)
        {
            int[] resType = new int[2];
            resType[1] = 2;

            if (NumberScales.MORE.Where(s => s.Key == count).Count() > 0)
                resType[0] = 0;
            else if (count < 8)
            {
                resType[0] = getResTypeOne(count, resType[1]);
            }
            else if (count < 12)
            {
                resType[1] = 3;
                resType[0] = getResTypeOne(count, resType[1]);
            }
            else if (count == 12)
            {
                resType[1] = 4;
                resType[0] = getResTypeOne(count, resType[1]);
            }
            else
            {
                resType[1] = 5;
                resType[0] = getResTypeOne(count, resType[1]);
            }
            return resType;
        }

        /// <summary>
        /// Gets the resource type one.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="divider">The divider.</param>
        /// <returns></returns>
        private static int getResTypeOne(int count, int divider)
        {
            if (count % divider == 0)
                return 1;
            else
                return 2;
        }

        /// <summary>
        /// Fors the units.
        /// </summary>
        /// <param name="numSplit">The number split.</param>
        /// <param name="result">The result.</param>
        /// <returns></returns>
        private static string forUnits(string[] numSplit, string result)
        {
            if (parseNum(numSplit[0] + numSplit[1]) > 0)
                result += NumberScales.BIND + forRight(numSplit[0] + numSplit[1], numSplit[0], numSplit[1]);

            return result;
        }

        /// <summary>
        /// Fors the right.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns></returns>
        private static string forRight(string number, string first, string second)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i.ToString().Equals(first))
                {
                    if (i == 0)
                    {
                        for (int a = 1; a < 10; a++)
                        {
                            if (a.ToString().Equals(second))
                            {
                                return NumberScales.UNITS.Find(s => s.Key == a).Value + NumberScales.SPACE;
                            }
                        }

                        return null;
                    }
                    if (i == 1)
                    {
                        if (second.Equals("0".ToString()))
                            return NumberScales.DECIMALS[0].Value + NumberScales.SPACE;

                        return NumberScales.TENS.Find(s => s.Key.ToString().Equals(number)).Value + NumberScales.SPACE;
                    }
                    else
                    {
                        string result = NumberScales.DECIMALS.Find(s => s.Key == i).Value + NumberScales.SPACE;
                        if (int.Parse(second) > 0)
                        {
                            result += forRight(number, "0", second);
                        }
                        return result;
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// Fills the array.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        private static string[] fillArray(string number)
        {
            return number.ToCharArray().Select(c => c.ToString()).ToArray();
        }

        /// <summary>
        /// Removes the number.
        /// </summary>
        /// <param name="numSplit">The number split.</param>
        /// <returns></returns>
        private static string[] removeNum(string[] numSplit)
        {
            var tempSplit = numSplit.ToList();
            tempSplit.RemoveAt(0);
            numSplit = tempSplit.ToArray();
            return numSplit;
        }

        /// <summary>
        /// Parses the number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        private static int parseNum(string number)
        {
            return int.Parse(number);
        }

        /// <summary>
        /// Breaks the word.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <returns></returns>
        private string[] breakWord(string p)
        {
            return p.Split('.');
        }
    }
}
