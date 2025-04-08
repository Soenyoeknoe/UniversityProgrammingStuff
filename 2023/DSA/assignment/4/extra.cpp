#include <gtest/gtest.h>
#include <iostream>
#include <vector>
#include <string>
#include <algorithm>
#include "calc.hpp"

const double EPS = 0.01;

// Doubles
TEST(Double, addition) {
  std::string input {"9.999 + 6.782"};
  EXPECT_NEAR(Calc::eval(input), 9.999 + 6.782, EPS);
}

TEST(Double, multiplication) {
  std::string input {"78.2387 * 8.9090"};
  EXPECT_NEAR(Calc::eval(input), 78.2387 * 8.9090, EPS);
}

TEST(Double, compound) {
  std::string input {"3.234 * 5.10 + 1.11"};
  EXPECT_NEAR(Calc::eval(input), 3.234 * 5.10 + 1.11, EPS);
}

TEST(Double, leadingZero) {
  std::string input {"0.893 * 1.23"};
  EXPECT_NEAR(Calc::eval(input), 0.893 * 1.23, EPS);
}

TEST(Double, noLeadingZero) {
  std::string input {".893 * 1.23"};
  EXPECT_NEAR(Calc::eval(input), .893 * 1.23, EPS);
}

TEST(Double, noLeadingZeroOrderReversed) {
  std::string input {"1.23 * .893"};
  EXPECT_NEAR(Calc::eval(input), 1.23 * .893, EPS);
}

TEST(Double, decimalInsideparen) {
  std::string input {"(0.23 * 0.893)"};
  EXPECT_NEAR(Calc::eval(input), 0.23 * 0.893, EPS);
}

TEST(Double, decimalNoLeadingZeroInsideparen) {
  std::string input {"(.23 * .893)"};
  EXPECT_NEAR(Calc::eval(input), .23 * .893, EPS);
}

// Unary Minus 

TEST(UnaryMinus, unaryMinusAtStart) {
  std::string input {"-1 * 5"};
  EXPECT_DOUBLE_EQ(Calc::eval(input), -5);
}

TEST(UnaryMinus, unaryMinusAfterOp) {
  std::string input {"5 * -1"};
  EXPECT_DOUBLE_EQ(Calc::eval(input), -5);
}

TEST(UnaryMinus, twoUnaryMinus) {
  std::string input {"-10 * -3"};
  EXPECT_DOUBLE_EQ(Calc::eval(input), 30);
}

TEST(UnaryMinus, twoUnaryMinusDivision) {
  std::string input {"-10 / -2"};
  EXPECT_DOUBLE_EQ(Calc::eval(input), 5);
}

TEST(UnaryMinus, unaryMinusBeforeParen) {
  std::string input {"-(4+2)"};
  EXPECT_DOUBLE_EQ(Calc::eval(input), -6);
}

TEST(UnaryMinus, unaryMinusBeforeParenMult) {
  std::string input {"-(4*2)"};
  EXPECT_DOUBLE_EQ(Calc::eval(input), -8);
}

TEST(UnaryMinus, unaryMinusBeforeParenSub) {
  std::string input {"-(4-2)"};
  EXPECT_DOUBLE_EQ(Calc::eval(input), -2);
}

TEST(UnaryMinus, unaryMinusAfterParen) {
  std::string input {"3 + (-4 * 2)"};
  EXPECT_DOUBLE_EQ(Calc::eval(input), 3 + (-4 * 2));
}

TEST(UnaryMinus, unaryMinusInsideParen) {
  std::string input {"3 + (4 * -2)"};
  EXPECT_DOUBLE_EQ(Calc::eval(input), 3 + (4 * -2));
}

TEST(UnaryMinus, differenceTwoExpressions) {
  std::string input {"(5+3) - (2-1)"};
  EXPECT_DOUBLE_EQ(Calc::eval(input), 7);
}

// Unary + Double

TEST(UnaryMinusAndDouble, addition) {
  std::string input {"-0.328 + 2.1"};
  EXPECT_DOUBLE_EQ(Calc::eval(input), -0.328 + 2.1);
}

TEST(UnaryMinusAndDouble, additionNoLeadingZero) {
  std::string input {"-.328 + 2.1"};
  EXPECT_DOUBLE_EQ(Calc::eval(input), -.328 + 2.1);
}

// Exponentiation

TEST(Exp, simpleExp) {
  std::string input {"(2^3)"};
  EXPECT_DOUBLE_EQ(Calc::eval(input), 8);
}

TEST(Exp, expAssociativity) {
  std::string input {"2^3^2"};
  EXPECT_DOUBLE_EQ(Calc::eval(input), 512);
}

TEST(Exp, expWithParen) {
  std::string input {"(2^3)^2"};
  EXPECT_DOUBLE_EQ(Calc::eval(input), 64);
}

TEST(Exp, expWithExpression) {
  std::string input {"2^(2+1)"};
  EXPECT_DOUBLE_EQ(Calc::eval(input), 8);
}

TEST(Exp, expWithNegativeExponent) {
  std::string input {"2^(0 - 3)"};
  EXPECT_DOUBLE_EQ(Calc::eval(input), 1.0/8.0);
}

TEST(Exp, expWithUnaryMinus) {
  std::string input {"2^(-3)"};
  EXPECT_DOUBLE_EQ(Calc::eval(input), 1.0/8.0);
}

TEST(Exp, negativeOfExponential) {
  std::string input {"-2^2"};
  EXPECT_DOUBLE_EQ(Calc::eval(input), -4);
}

int main(int argc, char* argv[]) {
  ::testing::InitGoogleTest(&argc, argv);
  return RUN_ALL_TESTS();
}