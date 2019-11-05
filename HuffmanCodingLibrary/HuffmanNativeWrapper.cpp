#include "HuffmanNativeWrapper.h"

extern "C" LIBRARY_EXPORT HuffmanTmp::OccurencesCounter * new_OccurencesCounter(const char* str) {
	std::string inputStream = str;
	return new HuffmanTmp::OccurencesCounter(str);
}
extern "C" LIBRARY_EXPORT void delete_OccurencesCounter(HuffmanTmp::OccurencesCounter * instance) {
	delete instance;
}

extern "C" LIBRARY_EXPORT HuffmanTmp::HuffmanTree * new_HuffmanTree(std::priority_queue<HuffmanTmp::Sign*, std::vector<HuffmanTmp::Sign*>, HuffmanTmp::Sign::CustomPqComparator> * pqSignContainer) {
	return new HuffmanTmp::HuffmanTree(pqSignContainer);
}
extern "C" LIBRARY_EXPORT void delete_HuffmanTree(HuffmanTmp::HuffmanTree * instance) {
	delete instance;
}

extern "C" LIBRARY_EXPORT HuffmanTmp::HuffmanTreeTraverse * new_HuffmanTreeTraverse(HuffmanTmp::Sign * apex) {
	return new HuffmanTmp::HuffmanTreeTraverse(apex);
}
extern "C" LIBRARY_EXPORT void delete_HuffmanTreeTraverse(HuffmanTmp::HuffmanTreeTraverse * instance) {
	delete instance;
}

extern "C" LIBRARY_EXPORT std::priority_queue<HuffmanTmp::Sign*, std::vector<HuffmanTmp::Sign*>, HuffmanTmp::Sign::CustomPqComparator> * GetPqSignContainer(HuffmanTmp::OccurencesCounter * instance) {
	return instance->GetPqSignContainer();
}

extern "C" LIBRARY_EXPORT HuffmanTmp::Sign * GetApex(HuffmanTmp::HuffmanTree * instance) {
	return instance->GetApex();
}

extern "C" LIBRARY_EXPORT char GetSignChar(HuffmanTmp::Sign * sign) {
	return sign->GetSign();
}
extern "C" LIBRARY_EXPORT int GetNumOfOccurrences(HuffmanTmp::Sign * sign) {
	return sign->GetNumOfOccurrences();
}
extern "C" LIBRARY_EXPORT void SetSignCode(HuffmanTmp::Sign * sign, const char* code) {
	std::string str = code;
	sign->SetCodedSign(str);
}
extern "C" LIBRARY_EXPORT std::string GetSignCoded(HuffmanTmp::Sign * sign) {
	return sign->GetCodedSign();
}
extern "C" LIBRARY_EXPORT HuffmanTmp::Sign * GetLeftNode(HuffmanTmp::Sign * sign) {
	return sign->GetLeftNode();
}
extern "C" LIBRARY_EXPORT HuffmanTmp::Sign * GetRightNode(HuffmanTmp::Sign * sign) {
	return sign->GetRightNode();
}
extern "C" LIBRARY_EXPORT void SetLeftNodeNull(HuffmanTmp::Sign * sign) {
	sign->SetLeftNodeNull();
}
extern "C" LIBRARY_EXPORT void SetRightNodeNull(HuffmanTmp::Sign * sign) {
	sign->SetRightNodeNull();
}
extern "C" LIBRARY_EXPORT int GetId(HuffmanTmp::Sign * sign) {
	return sign->GetId();
}
