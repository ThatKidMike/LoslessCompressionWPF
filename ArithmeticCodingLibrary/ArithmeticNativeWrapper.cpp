#include "ArithmeticNativeWrapper.h"

extern "C" LIBRARY_EXPORT ArithmeticCodingTmp::ProcessInput* new_ProcessInput(const char *str) {
	std::string inputStream = str;
	return new ArithmeticCodingTmp::ProcessInput(str);
}

extern "C" LIBRARY_EXPORT void delete_ProcessInput(ArithmeticCodingTmp::ProcessInput* instance) {
	delete instance;
}

extern "C" LIBRARY_EXPORT char new_GetSign(ArithmeticCodingTmp::ProcessInput* instance, int numPosition) {
	return instance->GetVecSign(numPosition);
}

extern "C" LIBRARY_EXPORT int new_GetProbability(ArithmeticCodingTmp::ProcessInput* instance, int numPosition) {
	return instance->GetVecProbability(numPosition);
}

extern "C" LIBRARY_EXPORT double new_GetStartRange(ArithmeticCodingTmp::ProcessInput* instance, int numPosition) {
	return instance->GetVecStartRange(numPosition);
}

extern "C" LIBRARY_EXPORT double new_GetEndRange(ArithmeticCodingTmp::ProcessInput* instance, int numPosition) {
	return instance->GetVecEndRange(numPosition);
}

extern "C" LIBRARY_EXPORT double new_GetEncodedStart(ArithmeticCodingTmp::ProcessInput* instance, int numPosition) {
	return instance->GetVecEncodedStart(numPosition);
}

extern "C" LIBRARY_EXPORT double new_GetEncodedEnd(ArithmeticCodingTmp::ProcessInput* instance, int numPosition) {
	return instance->GetVecEncodedEnd(numPosition);
}

extern "C" LIBRARY_EXPORT double new_GetEncode(ArithmeticCodingTmp::ProcessInput* instance) {
	return instance->GetFinalEncode();
}

