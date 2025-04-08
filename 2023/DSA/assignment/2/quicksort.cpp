#include <iostream>
#include <vector>
#include <utility>
#include "quicksort.hpp"

// shorten the name so we don't have to
// write the namespace Quicksort::vecIter
using vecIter = Quicksort::vecIter;

// Lomuto Partition as given in lecture 4.7
vecIter lomutoPartition(vecIter begin, vecIter end) {
  vecIter leftEnd = begin + 1;
  for (vecIter j = begin + 1; j < end; ++j) {
    if (*j <= *begin) {
      std::swap(*leftEnd, *j);
      ++leftEnd;
    }
  }
  std::swap(*begin, *(leftEnd-1));
  return leftEnd - 1;
}

// basic quicksort using Lomuto Partition
void Quicksort::basic(vecIter begin, vecIter end) {
  if (end - begin <= 1) {
    insertionSortBaseCase(begin, end);
    return;
  }
  vecIter pivotIt = lomutoPartition(begin, end);
  basic(begin, pivotIt);
  basic(pivotIt+1, end);
}

//This function performs insertion sort on the given sub-range [begin, end).
void Quicksort::insertionSortBaseCase(vecIter begin, vecIter end) {
  // your implementation goes here
  if (end - begin <= 1) {
        return;
    }
    for (vecIter iter1 = begin + 1 ; iter1 < end; ++iter1) {
        auto sort = *iter1;
        auto minus = iter1 - 1;
        while (minus >= begin && *minus > sort) {
            *(minus + 1) = *minus;
            --minus;
        }
        *(minus + 1) = sort;
    }
     
}
//This function is a modified version of insertion sort that uses the median-of-three pivot selection method to improve performance. 
void Quicksort::median3InsertionSortBaseCase(vecIter begin, vecIter end) {
  //your implementation goes here
  if (end - begin <= 1) {
    return;
  }
  if (end - begin <= 16) {
    insertionSortBaseCase(begin, end);
    return;
  }
  // median of three pivot selection
  vecIter mid = begin + (end - begin) / 2;
  auto first = *begin;
  auto middle = *mid;
  auto last = *(end - 1);
  auto pivot = std::max(std::min(first, middle), std::min(std::max(first, middle), last));
  vecIter iter1 = begin;
  vecIter iter2 = end - 1;
  while (iter1 <= iter2) {
    while (*iter1 < pivot) ++iter1;
    while (*iter2 > pivot) --iter2;
    if (iter1 <= iter2) {
      std::swap(*iter1, *iter2);
      ++iter1;
      --iter2;
    }
  }
  if (begin < iter2) {
    median3InsertionSortBaseCase(begin, iter2 + 1);
  }
  if (iter1 < end) {
    median3InsertionSortBaseCase(iter1, end);
  }
}
//This function is provided as an interface to test different sorting functions.
void Quicksort::thirdVariation(vecIter begin, vecIter end) {
  // your implementation goes here
  if (begin < end) {
        vecIter pivot = lomutoPartition(begin, end);
        thirdVariation(begin, pivot);
        thirdVariation(pivot + 1, end);
    }
}

void Quicksort::mySort(vecIter begin, vecIter end) {
  //basic(begin, end); //comment line 97,98,99 to do basic Sort
  //insertionSortBaseCase(begin, end); //comment line 96,98,99 to do insertion Sort
  median3InsertionSortBaseCase(begin, end); //comment line 96,97,99 to do median 3 Insertion Sort
  //thirdVariation(begin, end); //comment line 96,97,98 to do Third variations Sort
}