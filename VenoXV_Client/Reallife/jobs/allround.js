//----------------------------------//
///// VenoX Gaming & Fun 2020 © ///////
//////By Solid_Snake & VnX RL Crew////
////////www.venox-reallife.com////////
//----------------------------------//


import * as alt from 'alt-client';
import * as game from 'natives';
import { CreatePed, vnxCreateCEF, vnxDestroyCEF, ShowCursor } from '../../Globals/VnX-Lib';



alt.onServer('Job:ShowAcceptWindow', (headertext, boxtext, buttontext1, buttontext2) => {
	try {
		let JobAcceptWindow = vnxCreateCEF('Reallife:JobAcceptWindow', "Reallife/jobs/accept/main.html");
		ShowCursor(true);
		JobAcceptWindow.focus();
		JobAcceptWindow.on('Reallife:JobAcceptWindowDestroy', () => {
			JobAcceptWindow.unfocus();
			vnxDestroyCEF('Reallife:JobAcceptWindow');
		});
		JobAcceptWindow.on('Reallife:OnJobAcceptWindowClick', (click) => {
			if (click == 1) { alt.emitServer('accept_job_server', headertext); }
			JobAcceptWindow.unfocus();
			vnxDestroyCEF('Reallife:JobAcceptWindow');
			ShowCursor(false);
		});
		alt.setTimeout(() => {
			JobAcceptWindow.emit('JobAccept:Init', headertext, boxtext, buttontext1, buttontext2);
		}, 500);
	}
	catch{ }
});


alt.onServer('Job:ShowSelection1', (headertext, boxtext, buttontext1, buttontext2, buttontext3, buttondescription1, buttondescription2, buttondescription3, joblvl) => {
	try {
		let JobWindow = vnxCreateCEF('Reallife:JobWindow', "Reallife/jobs/selection-1/main.html");
		ShowCursor(true);
		JobWindow.focus();
		JobWindow.on('Reallife:JobWindowDestroy', () => {
			JobWindow.unfocus();
			vnxDestroyCEF('Reallife:JobWindow');
			ShowCursor(false);
		});
		JobWindow.on('job_window_1_button_c', (btn) => {
			JobWindow.unfocus();
			vnxDestroyCEF('Reallife:JobWindow');
			ShowCursor(false);
			alt.emitServer('Job:StartStage', btn);
		})
		alt.setTimeout(() => {
			JobWindow.emit('Job:Init', headertext, boxtext, buttontext1, buttontext2, buttontext3, buttondescription1, buttondescription2, buttondescription3, joblvl);
		}, 500);
	}
	catch{ }
});


alt.onServer('BusJob:CreateTimeout', (ms) => {
	try {
		alt.setTimeout(() => {
			alt.emitServer("BusJob:TimeoutDone");
		}, ms);
	}
	catch{ }
});









/* NPC's */
CreatePed("s_f_y_cop_01", new alt.Vector3(441.2622, -978.8309, 30.6896), 177.6991); // Police Stellen
CreatePed("a_m_y_acult_02", new alt.Vector3(2547.9636, 2579.7202, 37.9449), 72.5336); // KT Abgabe
CreatePed("a_m_m_tranvest_01", new alt.Vector3(2547.4983, 2581.1782, 37.9449), 151.3331); // KT Abgabe
CreatePed("ig_claypain", new alt.Vector3(-58.2157, -2244.898, 8.9560), 93.8773); // GangAutoShop


// JOBS //
// JOBS //
// JOBS //


CreatePed("s_m_m_pilot_01", new alt.Vector3(-1047.312, -2744.564, 21.3594), 333); // FlugJob
CreatePed("s_m_m_pilot_01", new alt.Vector3(438.2896, -626.1547, 28.70835), 90); // FlugJob
CreatePed("s_m_m_ups_01", new alt.Vector3(864.2459, -2312.139, 30.3), 90); // TruckerJob


CreatePed("s_m_y_ammucity_01", new alt.Vector3(21.88107, -1105.19, 29.79704), 160); // Ammu-Nation (Muss aus der AmmuNation datei gelöscht werden der PED)
CreatePed("s_m_y_ammucity_01", new alt.Vector3(2567.3176, 292.1545, 108.7349), 347.3555); // Ammu-Nation  
CreatePed("s_m_y_ammucity_01", new alt.Vector3(1692.1017, 3761.1545, 34.7053), 227.8246); // Ammu-Nation 
CreatePed("s_m_y_ammucity_01", new alt.Vector3(-331.6801, 6085.3755, 31.4548), 230.7451); // Ammu-Nation  
CreatePed("s_m_y_ammucity_01", new alt.Vector3(-3173.558, 1088.9904, 20.8387), 244.3055); // Ammu-Nation  
CreatePed("s_m_y_ammucity_01", new alt.Vector3(-1119.023, 2700.2097, 18.6161), 220.3011); // Ammu-Nation 
CreatePed("s_m_y_ammucity_01", new alt.Vector3(-1303.978, -394.9959, 36.6958), 76.6958); // Ammu-Nation  
CreatePed("s_m_y_ammucity_01", new alt.Vector3(254.1460, -50.6477, 69.9411), 71.2196); // Ammu-Nation  
CreatePed("s_m_y_ammucity_01", new alt.Vector3(-662.0509, -933.2979, 21.8295), 181.8458); // Ammu-Nation 
CreatePed("s_m_y_ammucity_01", new alt.Vector3(809.9637, -2159.293, 29.6190), 2.0918); // Ammu-Nation  
CreatePed("s_m_y_ammucity_01", new alt.Vector3(842.3348, -1035.670, 28.1949), 352.9427); // Ammu-Nation


// BANK //
// BANK //
// BANK //
CreatePed("s_m_m_ciasec_01", new alt.Vector3(-1211.861, -332.1641, 37.7809), 25.5676); // BANK
CreatePed("s_m_m_ciasec_01", new alt.Vector3(-351.4964, -51.2896, 49.0365), 340.0965); // BANK
CreatePed("s_m_m_ciasec_01", new alt.Vector3(313.7498, -280.4208, 54.1647), 339.9190); // BANK
CreatePed("s_m_m_ciasec_01", new alt.Vector3(149.3985, -1042.037, 29.3680), 337.1711); // BANK
CreatePed("s_m_m_ciasec_01", new alt.Vector3(-2961.170, 482.9008, 15.6970), 87.1794); // BANK
CreatePed("s_m_m_ciasec_01", new alt.Vector3(1174.9855, 2708.2053, 38.0879), 179.3288); // BANK 
CreatePed("s_m_m_ciasec_01", new alt.Vector3(-111.2077, 6469.9692, 31.6267), 132.3737); // BANK
CreatePed("s_m_m_ciasec_01", new alt.Vector3(254.0436, 222.4437, 106.2869), 166.8532); // PACCIFIC BANK 
CreatePed("s_m_m_ciasec_01", new alt.Vector3(248.7878, 224.3636, 106.2871), 164.1315); // PACCIFIC BANK 
CreatePed("s_m_m_ciasec_01", new alt.Vector3(243.6533, 226.2294, 106.2976), 166.7052); // PACCIFIC BANK 


// KLAMOTTENGESCHÄFT //
// KLAMOTTENGESCHÄFT //
// KLAMOTTENGESCHÄFT //


CreatePed("cs_andreas", new alt.Vector3(-165.0711, -302.7445, 39.7333), 256.5682); // Klamottengeschäft
CreatePed("csb_anita", new alt.Vector3(-822.9607, -1072.136, 11.3281), 216.4959); // Klamottengeschäft
CreatePed("a_m_y_business_02", new alt.Vector3(73.8082, -1392.734, 29.3761), 274.4417); // Klamottengeschäft
CreatePed("cs_andreas", new alt.Vector3(427.1636, -806.5073, 29.4911), 85.2890); // Klamottengeschäft
CreatePed("csb_anita", new alt.Vector3(-1194.035, -766.73, 17.3467), 217.7607); // Klamottengeschäft
CreatePed("a_m_y_business_02", new alt.Vector3(127.4631, -224.2565, 54.5578), 72.7298); // Klamottengeschäft
CreatePed("cs_andreas", new alt.Vector3(-708.2973, -152.3993, 37.4151), 119.9882); // Klamottengeschäft
CreatePed("csb_anita", new alt.Vector3(-1449.449, -238.8593, 49.8180), 48.3300); // Klamottengeschäft
CreatePed("a_m_y_business_02", new alt.Vector3(-3168.909, 1043.6388, 20.8632), 66.0227); // Klamottengeschäft
CreatePed("cs_andreas", new alt.Vector3(-1102.383, 2711.7104, 19.1079), 221.7238); // Klamottengeschäft
CreatePed("csb_anita", new alt.Vector3(612.5359, 2762.2820, 42.1217), 270.8093); // Klamottengeschäft
CreatePed("a_m_y_business_02", new alt.Vector3(1196.8094, 2711.7253, 38.2226), 182.6075); // Klamottengeschäft
CreatePed("cs_andreas", new alt.Vector3(1695.4166, 4822.9463, 42.0631), 97.2569); // Klamottengeschäft
CreatePed("csb_anita", new alt.Vector3(5.7597, 6511.2646, 31.8779), 43.1320); // Klamottengeschäft


// Friseursalon //
// Friseursalon //
// Friseursalon //


CreatePed("csb_anita", new alt.Vector3(-822.4943, -183.5546, 37.5689), 208.8652); // Friseursalon
CreatePed("a_m_y_business_02", new alt.Vector3(134.7252, -1707.938, 29.2916), 147.4230); // Friseursalon
CreatePed("cs_andreas", new alt.Vector3(-1284.164, -1115.418, 6.9901), 97.3994); // Friseursalon
CreatePed("csb_anita", new alt.Vector3(1930.8955, 3728.1099, 32.8444), 215.9498); // Friseursalon
CreatePed("a_m_y_business_02", new alt.Vector3(1211.5078, -470.7202, 66.2126), 77.8812); // Friseursalon
CreatePed("cs_andreas", new alt.Vector3(-30.7844, -151.6425, 57.1026), 341.5069); // Friseursalon
CreatePed("csb_anita", new alt.Vector3(-278.0271, 6230.4585, 31.6955), 44.7892); // Friseursalon


// Tattoo-Studio //
// Tattoo-Studio //
// Tattoo-Studio //


CreatePed("a_m_y_business_02", new alt.Vector3(319.8408, 181.2940, 103.5866), 251.0363); // Tattoo-Studio
CreatePed("cs_andreas", new alt.Vector3(1862.4102, 3748.4360, 33.0319), 25.6813); // Tattoo-Studio
CreatePed("csb_anita", new alt.Vector3(-292.0542, 6199.8320, 31.4871), 227.6733); // Tattoo-Studio
CreatePed("a_m_y_business_02", new alt.Vector3(-1152.044, -1424.024, 4.9545), 119.6521); // Tattoo-Studio
CreatePed("cs_andreas", new alt.Vector3(1324.6667, -1650.412, 52.2751), 132.2814); // Tattoo-Studio
CreatePed("csb_anita", new alt.Vector3(-3170.712, 1073.1750, 20.8292), 339.2451); // Tattoo-Studio