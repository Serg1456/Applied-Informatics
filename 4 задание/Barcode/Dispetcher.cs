using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barcode
{
    internal static class Dispetcher
    {
        public static void BuildEANEightFromFace(Person person)
        {
            var resultOfEncoding = BarcodeConverter.EncodeEightFaceConverter(person);
            VisualResultOfEncoding visualResult = new VisualResultOfEncoding();
            visualResult.DrawResultOfEncoding(resultOfEncoding);
            visualResult.Show();
        }
        public static void BuildEANFromDifferentAges(Person youngPerson, Person olderPerson)
        {
            var result = Calculator.CalculateFacesInDifferentAges(youngPerson, olderPerson);
            VisualResultOfEncoding visualResult = new VisualResultOfEncoding();
            visualResult.DrawResultOfDifferentAges(result);
            visualResult.Show();
        }
    }
}
