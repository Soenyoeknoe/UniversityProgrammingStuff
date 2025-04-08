#include <vector>
#include <utility>
#include "nuts_and_bolts.hpp"
#include "match.hpp"

template<typename T, typename X>
//add a template to the match.cpp so that we can create object and axis elements since they are are different types.
//The partition function takes in a vector of objects, a start and end index, and an axis value.
int partition(std::vector<T>& object, int start, int end, X axis) {
    T tmpPivot(0), tmp(0);
    int partitionProg = start; //the partitionProg index is used which keeps track of the latest position of the pivot element.
    for(int i = start; i <= end; i++) {
        if(object[i] == axis) {
            tmpPivot = object[i];
            object[i] = object[partitionProg];
            object[partitionProg++] = tmpPivot;
        }
    }
    int left = start + 1, right = end;
    while(left <= right) {
        while(left <= end && object[left] <= axis) left++;
        while(right > start && object[right] >= axis) right--;
        if(left >= right) {
            tmp = object[right];
            object[right] = object[start];
            object[start] = tmp;
        } else {
            tmp = object[left];
            object[left] = object[right];
            object[right] = tmp;
        }
    }
    return right;
}
//The quickSort function takes in vectors of nuts and bolts and startSortIndex and endSortIndex will record and index, and uses the first bolt as the pivot element to match the nuts and nuts and bolts.
void quickSort(std::vector<Nut>& nuts, std::vector<Bolt>& bolts, int startSortIndex, int endSortIndex) {
    if(startSortIndex <= endSortIndex) {
        int partitionResult = partition<Nut, Bolt>(nuts, startSortIndex, endSortIndex, bolts[startSortIndex]);
        partition<Bolt, Nut>(bolts, startSortIndex, endSortIndex, nuts[partitionResult]);
        quickSort(nuts, bolts, startSortIndex, partitionResult - 1);
        quickSort(nuts, bolts, partitionResult + 1, endSortIndex);
    }
}//matchNutsAndBolts function just takes in vectors of nuts and bolts, and calls quickSort on them to match the nuts and bolts.
void matchNutsAndBolts(std::vector<Nut>& nuts, std::vector<Bolt>& bolts) {
    quickSort(nuts, bolts, 0, nuts.size() - 1);
}




