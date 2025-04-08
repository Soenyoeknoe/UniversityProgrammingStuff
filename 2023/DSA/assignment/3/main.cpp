#include <gtest/gtest.h>
#include <iostream>
#include <vector>
#include "nuts_and_bolts.hpp"
#include "match.hpp"

// The next few tests demonstrate how you 
// can compare nuts and bolts.
// All comparison operators are defined
// These tests are not part of the marker.
TEST(match, LessThan) {
  EXPECT_TRUE(Nut {5} < Bolt {7});
  EXPECT_FALSE(Nut {5} < Bolt {5});
  EXPECT_FALSE(Nut {5} < Bolt {3});
  EXPECT_TRUE(Bolt {5} < Nut {7});
  EXPECT_FALSE(Bolt {5} < Nut {5});
  EXPECT_FALSE(Bolt {5} < Nut {3});
}

TEST(match, LessThanOrEqual) {
  EXPECT_TRUE(Nut {5} <= Bolt {7});
  EXPECT_TRUE(Nut {5} <= Bolt {5});
  EXPECT_FALSE(Nut {5} <= Bolt {3});
  EXPECT_TRUE(Bolt {5} <= Nut {7});
  EXPECT_TRUE(Bolt {5} <= Nut {5});
  EXPECT_FALSE(Bolt {5} <= Nut {3});
}

TEST(match, greaterThan) {
  EXPECT_FALSE(Nut {5} > Bolt {7});
  EXPECT_FALSE(Nut {5} > Bolt {5});
  EXPECT_TRUE(Nut {5} > Bolt {3});
  EXPECT_FALSE(Bolt {5} > Nut {7});
  EXPECT_FALSE(Bolt {5} > Nut {5});
  EXPECT_TRUE(Bolt {5} > Nut {3});
}

TEST(match, greaterThanOrEqual) {
  EXPECT_FALSE(Nut {5} >= Bolt {7});
  EXPECT_TRUE(Nut {5} >= Bolt {5});
  EXPECT_TRUE(Nut {5} >= Bolt {3});
  EXPECT_FALSE(Bolt {5} >= Nut {7});
  EXPECT_TRUE(Bolt {5} >= Nut {5});
  EXPECT_TRUE(Bolt {5} >= Nut {3});
}

TEST(match, Equal) {
  EXPECT_FALSE(Nut {5} == Bolt {7});
  EXPECT_TRUE(Nut {5} == Bolt {5});
  EXPECT_FALSE(Nut {5} == Bolt {3});
  EXPECT_FALSE(Bolt {5} == Nut {7});
  EXPECT_TRUE(Bolt {5} == Nut {5});
  EXPECT_FALSE(Bolt {5} == Nut {3});
}

// now some tests of the match function
TEST(match, sizeOne) {
  std::vector<Bolt> bolts { Bolt {1} };
  std::vector<Nut> nuts   { Nut {1} };
  matchNutsAndBolts(nuts, bolts);
  for (std::size_t i = 0; i < bolts.size(); ++i) {
    EXPECT_EQ(bolts[i], nuts[i]);
  }
}

TEST(match, sizeTwoAlreadyMatched) {
  std::vector<Bolt> bolts { Bolt {1}, Bolt {2} };
  std::vector<Nut> nuts   { Nut {1}, Nut {2} };
  matchNutsAndBolts(nuts, bolts);
  for (std::size_t i = 0; i < bolts.size(); ++i) {
    EXPECT_EQ(bolts[i], nuts[i]);
  }
}

TEST(match, sizeTwoNotMatched) {
  std::vector<Bolt> bolts { Bolt {2}, Bolt {1} };
  std::vector<Nut> nuts   { Nut {1}, Nut {2} };
  matchNutsAndBolts(nuts, bolts);
  for (std::size_t i = 0; i < bolts.size(); ++i) {
    EXPECT_EQ(bolts[i], nuts[i]);
  }
}

TEST(match, sizeThree) {
  std::vector<Bolt> bolts { Bolt {3}, Bolt {2}, Bolt {1} };
  std::vector<Nut> nuts   { Nut {1}, Nut {2}, Nut {3} };
  matchNutsAndBolts(nuts, bolts);
  for (std::size_t i = 0; i < bolts.size(); ++i) {
    EXPECT_EQ(bolts[i], nuts[i]);
  }
}

TEST(match, sizeThreePermutation) {
  std::vector<Bolt> bolts { Bolt {3}, Bolt {2}, Bolt {1} };
  std::vector<Nut> nuts   { Nut {1}, Nut {3}, Nut {2} };
  matchNutsAndBolts(nuts, bolts);
  for (std::size_t i = 0; i < bolts.size(); ++i) {
    EXPECT_EQ(bolts[i], nuts[i]);
  }
}

TEST(match, uniqueSizes) {
  std::vector<Bolt> bolts { Bolt {7}, Bolt {5}, Bolt {3}, Bolt {6},
                            Bolt {2}, Bolt {8}, Bolt {9}};
  std::vector<Nut> nuts   { Nut {5}, Nut {6}, Nut {9}, Nut {7},
                            Nut {8}, Nut {3}, Nut {2}};
  matchNutsAndBolts(nuts, bolts);
  for (std::size_t i = 0; i < bolts.size(); ++i) {
    EXPECT_EQ(bolts[i], nuts[i]);
  }
}

TEST(match, uniqueSizesPermutation) {
  std::vector<Bolt> bolts { Bolt {7}, Bolt {5}, Bolt {3}, Bolt {6},
                            Bolt {2}, Bolt {8}, Bolt {9}};
  std::vector<Nut> nuts   { Nut {5}, Nut {6}, Nut {9}, Nut {7},
                            Nut {8}, Nut {3}, Nut {2}};
  matchNutsAndBolts(nuts, bolts);
  for (std::size_t i = 0; i < bolts.size(); ++i) {
    EXPECT_EQ(bolts[i], nuts[i]);
  }
}

TEST(match, smallSizeDuplicates) {
  std::vector<Bolt> bolts { Bolt {5}, Bolt {5}, Bolt {2}};
  std::vector<Nut> nuts   { Nut {5}, Nut {2}, Nut {5}};
  matchNutsAndBolts(nuts, bolts);
  for (std::size_t i = 0; i < bolts.size(); ++i) {
    EXPECT_EQ(bolts[i], nuts[i]);
  }
}

TEST(match, twoRepeating) {
  std::vector<Bolt> bolts { Bolt {1}, Bolt {5}, Bolt {1}, Bolt {5},
                            Bolt {1}};
  std::vector<Nut> nuts   { Nut {5}, Nut {5}, Nut {1}, Nut {1}, Nut {1} };
  matchNutsAndBolts(nuts, bolts);
  for (std::size_t i = 0; i < bolts.size(); ++i) {
    EXPECT_EQ(bolts[i], nuts[i]);
  }
}

TEST(match, largerExampleWithDuplicates) {
  std::vector<Bolt> bolts { Bolt {7}, Bolt {2}, Bolt {3}, Bolt {6},
                            Bolt {2}, Bolt {6}, Bolt {3}};
  std::vector<Nut> nuts   { Nut {2}, Nut {6}, Nut {3}, Nut {7},
                            Nut {6}, Nut {3}, Nut {2}};
  matchNutsAndBolts(nuts, bolts);
  for (std::size_t i = 0; i < bolts.size(); ++i) {
    EXPECT_EQ(bolts[i], nuts[i]);
  }
}
TEST(match, largerExampleUnique) {
  std::vector<Bolt> bolts { Bolt {1}, Bolt {2}, Bolt {3}, Bolt {4},
                            Bolt {5}, Bolt {6}, Bolt {7}, Bolt {8}};
  std::vector<Nut> nuts   { Nut {2}, Nut {6}, Nut {3}, Nut {7},
                            Nut {5}, Nut {1}, Nut {4}, Nut {8}};
  matchNutsAndBolts(nuts, bolts);
  for (std::size_t i = 0; i < bolts.size(); ++i) {
    EXPECT_EQ(bolts[i], nuts[i]);
  }
}

int main(int argc, char* argv[]) {
    ::testing::InitGoogleTest(&argc, argv);
    return RUN_ALL_TESTS();
}