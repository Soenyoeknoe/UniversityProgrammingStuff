#include <gtest/gtest.h>
#include <iostream>
#include <vector>
#include <string>
#include "postorder.hpp"

/***
Formula: 1 + 1
        +
       / \
      1   1
***/
TEST(postorder, onePlusOne) {
  Node leftOperand {"1"};
  Node rightOperand {"1"};
  Node root {"+", &leftOperand, &rightOperand};
  std::vector<std::string> answer {"1", "1", "+"};
  EXPECT_EQ(postorder(&root), answer);
}

/***
Formula: 1 + 3 * 5
        +
       / \
      1   *
         / \
        3   5
***/
TEST(postorder, onePlusThreeTimesFive) {
  Node leftTimesOperand {"3"};
  Node rightTimesOperand {"5"};
  Node times {"*", &leftTimesOperand, &rightTimesOperand};
  Node leftPlusOperand {"1"};
  Node root {"+", &leftPlusOperand, &times};
  std::vector<std::string> answer {"1", "3", "5", "*", "+"};
  EXPECT_EQ(postorder(&root), answer);
}

/***
Formula: 6 * 7 - 3 + 1
        +
       / \
      -   1
     / \
    *   3
   / \
  6   7 
***/
TEST(postorder, sixTimesSevenMinusThreePlusOne) {
  Node leftTimesOperand {"6"};
  Node rightTimesOperand {"7"};
  Node times {"*", &leftTimesOperand, &rightTimesOperand};
  Node rightMinusOperand {"3"};
  Node minus {"-", &times, &rightMinusOperand};
  Node rightPlusOperand {"1"};
  Node root {"+", &minus, &rightPlusOperand};
  std::vector<std::string> answer {"6", "7", "*", "3", "-", "1", "+"};
  EXPECT_EQ(postorder(&root), answer);
}

/***
Formula: (4 + 3) * (2 + 7)
         *
       /   \
      +     +
     / \   / \
    4   3 2   7
***/
TEST(postorder, fourPlusThreeTimesTwoPlusSeven) {
  Node leftLeftPlusOperand {"4"};
  Node rightLeftPlusOperand {"3"};
  Node leftRightPlusOperand {"2"};
  Node rightRightPlusOperand {"7"};
  Node leftPlus {"+", &leftLeftPlusOperand, &rightLeftPlusOperand};
  Node rightPlus {"+", &leftRightPlusOperand, &rightRightPlusOperand};
  Node root {"*", &leftPlus, &rightPlus};
  std::vector<std::string> answer {"4", "3", "+", "2", "7", "+", "*"};
  EXPECT_EQ(postorder(&root), answer);
}

/***
Formula: (4 + 3) - 2 * 6
         -
       /   \
      +     *
     / \   / \
    4   3 2   6
***/
TEST(postorder, fourPlusThreeMinusTwoTimesSix) {
  Node leftPlusOperand {"4"};
  Node rightPlusOperand {"3"};
  Node leftTimesOperand {"2"};
  Node rightTimesOperand {"6"};
  Node plus {"+", &leftPlusOperand, &rightPlusOperand};
  Node times {"*", &leftTimesOperand, &rightTimesOperand};
  Node root {"-", &plus, &times};
  std::vector<std::string> answer {"4", "3", "+", "2", "6", "*", "-"};
  EXPECT_EQ(postorder(&root), answer);
}

int main(int argc, char* argv[]) {
  ::testing::InitGoogleTest(&argc, argv);
  return RUN_ALL_TESTS();
}