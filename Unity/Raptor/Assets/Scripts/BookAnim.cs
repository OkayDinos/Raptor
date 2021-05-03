//* Morgan Finney
//* www.pdox.uk
//* Apr 21
//* For DES203 | Project Raptor | 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Raptor
{
    public class BookAnim : MonoBehaviour
    {
        public Animator bookCoverAC, bookPaperAC;

        public void SetBookClosed(bool state)
        {
            bookCoverAC.SetBool("Close", state);
            bookPaperAC.SetBool("Close", state);
        }

    }
}
