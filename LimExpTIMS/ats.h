//Headder for ATS Plugin
//Author Tetsu Otter
#include <windows.h>

//DLL importを短縮
#define DE extern "C" __declspec(dllexport)
//何のためか忘れたけど入れとく
#define SC __stdcall
//プラグインのバージョン
#define PI_VERSION 0x00020000

struct Spec		//列車のスペックに関する情報
{
	int B = 0;	//ブレーキ段数
	int P = 0;	//ノッチ段数
	int A = 0;	//ATS確認段数
	int J = 0;	//常用最大段数
	int C = 0;	//編成車両数
};
struct State		//列車状態に関する情報
{
	double Z = 0;	//列車位置[m]
	float V = 0;	//列車速度[km/h]
	int T = 0;		//0時からの経過時間[ms]
	float BC = 0;	//BC圧力[kPa]
	float MR = 0;	//MR圧力[kPa]
	float ER = 0;	//ER圧力[kPa]
	float BP = 0;	//BP圧力[kPa]
	float SAP = 0;	//SAP圧力[kPa]
	float I = 0;	//電流[A]
};
struct Hand		//ハンドル位置に関する情報
{
	int B = 0;	//ブレーキハンドル位置
	int P = 0;	//ノッチハンドル位置
	int R = 0;	//レバーサーハンドル位置
	int C = 0;	//定速制御状態
};
struct Beacon		//Beaconに関する情報
{
	int Num = 0;	//Beaconの番号
	int Sig = 0;	//対応する閉塞の現示番号
	float X = 0;	//対応する閉塞までの距離[m]
	int Data = 0;	//Beaconの第三引数の値
};

Hand handle;
enum Reverser	//レバーサー位置
{
	Back = -1,	//後進
	Neutral,	//中立
	Forward		//前進
};
enum ConstSPInfo//定速制御の状態
{
	Continue,	//前回の状態を継続する
	Enable,		//有効化する
	Disable		//無効化する
};
enum HornInfo	//警笛の番号
{
	Horn1,		//Primary Horn
	Horn2,		//Secondary Horn
	MusicHorn	//Horn Music
};
enum SoundInfo	//サウンドの操作情報
{
	PlayLoop,	//繰り返し再生する
	PlayOnce,	//1度だけ再生する
	PlayContinue,	//前回の状態を継続する
	Stop = -1000//再生を停止する
};
enum InitialPosition	//ハンドルの初期位置設定
{
	Service,			//常用ブレーキ(B67?)
	Emergency,			//非常ブレーキ(EB)
	Removed				//抜き取り位置
};
enum ATSKeys	//キー押下情報
{
	S,A1,A2,B1,B2,C1,C2,D,E,F,G,H,I,J,K,L
};

DE void SC Load(void);
DE void SC Dispose(void);
DE int SC GetPluginVersion(void);
DE void SC SetVehicleSpec(Spec);
DE void SC Initialize(int);
DE Hand SC Elapse(State, int *, int *);
DE void SC SetPower(int);
DE void SC SetBrake(int);
DE void SC SetReverser(int);
DE void SC KeyDown(int);
DE void SC KeyUp(int);
DE void SC HornBlow(int);
DE void SC DoorOpen(void);
DE void SC DoorClose(void);
DE void SC SetSignal(int);
DE void SC SetBeaconData(Beacon);