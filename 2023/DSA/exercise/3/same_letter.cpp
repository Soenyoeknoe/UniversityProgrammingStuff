#include <string>
#include <algorithm>
#include "same_letters.hpp"

// given two strings, return true if and only if they contain 
// exactly the same letters including repetition.
bool sameLetters( const std::string& firstString, 
                  const std::string& secondString) {
  std::string theFirstString = firstString;
  std::sort(theFirstString.begin(), theFirstString.end());
  
  std::string theSecondString = secondString;
  std::sort(theSecondString.begin(), theSecondString.end());

  return theFirstString == theSecondString;
}
