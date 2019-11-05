#pragma once
#include "ProcessInput.h"
#include "SignsForCsharp.h"

#define LIBRARY_EXPORT __declspec(dllexport)

//constructor
extern "C" LIBRARY_EXPORT ArithmeticCodingTmp::ProcessInput * new_ProcessInput(const char* str, double probabilities[]);
extern "C" LIBRARY_EXPORT void delete_ProcessInput(ArithmeticCodingTmp::ProcessInput * instance);

extern "C" LIBRARY_EXPORT char new_GetSign(ArithmeticCodingTmp::ProcessInput * instance, int numPosition);
extern "C" LIBRARY_EXPORT double new_GetProbability(ArithmeticCodingTmp::ProcessInput * instance, int numPosition);
extern "C" LIBRARY_EXPORT double new_GetStartRange(ArithmeticCodingTmp::ProcessInput * instance, int numPosition);
extern "C" LIBRARY_EXPORT double new_GetEndRange(ArithmeticCodingTmp::ProcessInput * instance, int numPosition);
extern "C" LIBRARY_EXPORT double new_GetEncodedStart(ArithmeticCodingTmp::ProcessInput * instance, int numPosition);
extern "C" LIBRARY_EXPORT double new_GetEncodedEnd(ArithmeticCodingTmp::ProcessInput * instance, int numPosition);
extern "C" LIBRARY_EXPORT double new_GetEncode(ArithmeticCodingTmp::ProcessInput * instance);

