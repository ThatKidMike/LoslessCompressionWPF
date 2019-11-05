#pragma once
#include "OccurencesCounter.h"
#include "HuffmanTree.h"
#include "HuffmanTreeTraverse.h"
#include "Sign.h"

#define LIBRARY_EXPORT __declspec(dllexport)

extern "C" LIBRARY_EXPORT HuffmanTmp::OccurencesCounter * new_OccurencesCounter(const char* str);
extern "C" LIBRARY_EXPORT void delete_OccurencesCounter(HuffmanTmp::OccurencesCounter * instance);
extern "C" LIBRARY_EXPORT HuffmanTmp::HuffmanTree * new_HuffmanTree(std::priority_queue<HuffmanTmp::Sign*, std::vector<HuffmanTmp::Sign*>, HuffmanTmp::Sign::CustomPqComparator> * pqSignContainer);
extern "C" LIBRARY_EXPORT void delete_HuffmanTree(HuffmanTmp::HuffmanTree * instance);
extern "C" LIBRARY_EXPORT HuffmanTmp::HuffmanTreeTraverse * new_HuffmanTreeTraverse(HuffmanTmp::Sign * apex);
extern "C" LIBRARY_EXPORT void delete_HuffmanTreeTraverse(HuffmanTmp::HuffmanTreeTraverse * instance);
extern "C" LIBRARY_EXPORT std::priority_queue<HuffmanTmp::Sign*, std::vector<HuffmanTmp::Sign*>, HuffmanTmp::Sign::CustomPqComparator> * GetPqSignContainer(HuffmanTmp::OccurencesCounter * instance);
extern "C" LIBRARY_EXPORT HuffmanTmp::Sign * GetApex(HuffmanTmp::HuffmanTree * instance);
extern "C" LIBRARY_EXPORT char GetSignChar(HuffmanTmp::Sign * sign);
extern "C" LIBRARY_EXPORT int GetNumOfOccurrences(HuffmanTmp::Sign * sign);
extern "C" LIBRARY_EXPORT void SetSignCode(HuffmanTmp::Sign * sign, const char* code);
extern "C" LIBRARY_EXPORT std::string GetSignCoded(HuffmanTmp::Sign * sign);
extern "C" LIBRARY_EXPORT HuffmanTmp::Sign * GetLeftNode(HuffmanTmp::Sign * sign);
extern "C" LIBRARY_EXPORT HuffmanTmp::Sign * GetRightNode(HuffmanTmp::Sign * sign);
extern "C" LIBRARY_EXPORT void SetLeftNodeNull(HuffmanTmp::Sign * sign);
extern "C" LIBRARY_EXPORT void SetRightNodeNull(HuffmanTmp::Sign * sign);