using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace TowerDefense
{
    class Mapa
    {
        public static List<Slot> CrearSlots()
        {
            List<Slot> slots =
                new List<Slot>();
            Slot slot1 = new Slot();

            slot1.PosicionTorre =
                new Vector2(235, 160);

            slot1.AreaConstruccion =
                new Rectangle(
                    235,
                    179,
                    90,
                    80
                );

            slot1.TorreColocada = false;

            slots.Add(slot1);


            Slot slot2 = new Slot();

            slot2.PosicionTorre =
                new Vector2(365, 160);

            slot2.AreaConstruccion =
                new Rectangle(
                    365,
                    179,
                    90,
                    80
                );

            slot2.TorreColocada = false;

            slots.Add(slot2);

            Slot slot3 = new Slot();

            slot3.PosicionTorre =
                new Vector2(490, 160);

            slot3.AreaConstruccion =
                new Rectangle(
                    492,
                    179,
                    90,
                    80
                );

            slot3.TorreColocada = false;

            slots.Add(slot3);

            Slot slot4 = new Slot();

            slot4.PosicionTorre =
                new Vector2(492, 260);

            slot4.AreaConstruccion =
                new Rectangle(
                    492,
                    280,
                    90,
                    80
                );

            slot4.TorreColocada = false;

            slots.Add(slot4);

            Slot slot5 = new Slot();

            slot5.PosicionTorre =
                new Vector2(320, -5);

            slot5.AreaConstruccion =
                new Rectangle(
                    320,
                    15,
                    90,
                    73
                );

            slot5.TorreColocada = false;

            slots.Add(slot5);

            Slot slot6 = new Slot();

            slot6.PosicionTorre =
                new Vector2(445, -5);

            slot6.AreaConstruccion =
                new Rectangle(
                    445,
                    15,
                    90,
                    73
                );

            slot6.TorreColocada = false;

            slots.Add(slot6);

            Slot slot7 = new Slot();

            slot7.PosicionTorre =
                new Vector2(565, -5);

            slot7.AreaConstruccion =
                new Rectangle(
                    565,
                    15,
                    90,
                    73
                );

            slot7.TorreColocada = false;

            slots.Add(slot7);

            Slot slot8 = new Slot();

            slot8.PosicionTorre =
                new Vector2(698, 23);

            slot8.AreaConstruccion =
                new Rectangle(
                    698,
                    38,
                    90,
                    80
                );

            slot8.TorreColocada = false;

            slots.Add(slot8);

            Slot slot9 = new Slot();

            slot9.PosicionTorre =
                new Vector2(698, 115);

            slot9.AreaConstruccion =
                new Rectangle(
                    700,
                    130,
                    90,
                    75
                );

            slot9.TorreColocada = false;

            slots.Add(slot9);

            Slot slot10 = new Slot();

            slot10.PosicionTorre =
                new Vector2(700, 200);

            slot10.AreaConstruccion =
                new Rectangle(
                    700,
                    218,
                    90,
                    75
                );

            slot10.TorreColocada = false;

            slots.Add(slot10);


            Slot slot11 = new Slot();

            slot11.PosicionTorre =
                new Vector2(822, 115);

            slot11.AreaConstruccion =
                new Rectangle(
                    822,
                    130,
                    90,
                    75
                );

            slot11.TorreColocada = false;

            slots.Add(slot11);


            Slot slot12 = new Slot();

            slot12.PosicionTorre =
                new Vector2(825, 200);

            slot12.AreaConstruccion =
                new Rectangle(
                    825,
                    220,
                    90,
                    75
                );

            slot12.TorreColocada = false;

            slots.Add(slot12);

            Slot slot13 = new Slot();

            slot13.PosicionTorre =
                new Vector2(940, 115);

            slot13.AreaConstruccion =
                new Rectangle(
                    940,
                    130,
                    90,
                    75
                );

            slot13.TorreColocada = false;

            slots.Add(slot13);

            Slot slot14 = new Slot();

            slot14.PosicionTorre =
                new Vector2(950, 200);

            slot14.AreaConstruccion =
                new Rectangle(
                    950,
                    215,
                    90,
                    75
                );

            slot14.TorreColocada = false;

            slots.Add(slot14);

            Slot slot15 = new Slot();

            slot15.PosicionTorre =
                new Vector2(1075, 200);

            slot15.AreaConstruccion =
                new Rectangle(
                    1075,
                    215,
                    90,
                    75
                );

            slot15.TorreColocada = false;

            slots.Add(slot15);

            Slot slot16 = new Slot();

            slot16.PosicionTorre =
                new Vector2(1185, 295);

            slot16.AreaConstruccion =
                new Rectangle(
                    1185,
                    310,
                    90,
                    75
                );

            slot16.TorreColocada = false;

            slots.Add(slot16);

            Slot slot17 = new Slot();

            slot17.PosicionTorre =
                new Vector2(1185, 400);

            slot17.AreaConstruccion =
                new Rectangle(
                    1185,
                    420,
                    90,
                    75
                );

            slot17.TorreColocada = false;

            slots.Add(slot17);

            Slot slot18 = new Slot();

            slot18.PosicionTorre =
                new Vector2(1315, 400);

            slot18.AreaConstruccion =
                new Rectangle(
                    1317,
                    420,
                    90,
                    75
                );

            slot18.TorreColocada = false;

            slots.Add(slot18);

            Slot slot19 = new Slot();

            slot19.PosicionTorre =
                new Vector2(1185, 495);

            slot19.AreaConstruccion =
                new Rectangle(
                    1185,
                    515,
                    90,
                    75
                );

            slot19.TorreColocada = false;

            slots.Add(slot19);

            Slot slot20 = new Slot();

            slot20.PosicionTorre =
                new Vector2(555, 368);

            slot20.AreaConstruccion =
                new Rectangle(
                    555,
                    387,
                    90,
                    73
                );

            slot20.TorreColocada = false;

            slots.Add(slot20);

            Slot slot21 = new Slot();

            slot21.PosicionTorre =
                new Vector2(680, 368);

            slot21.AreaConstruccion =
                new Rectangle(
                    680,
                    387,
                    90,
                    73
                );

            slot21.TorreColocada = false;

            slots.Add(slot21);

            Slot slot22 = new Slot();

            slot22.PosicionTorre =
                new Vector2(810, 368);

            slot22.AreaConstruccion =
                new Rectangle(
                    810,
                    387,
                    90,
                    73
                );

            slot22.TorreColocada = false;

            slots.Add(slot22);

            Slot slot23 = new Slot();

            slot23.PosicionTorre =
                new Vector2(947, 368);

            slot23.AreaConstruccion =
                new Rectangle(
                    947,
                    387,
                    90,
                    73
                );

            slot23.TorreColocada = false;

            slots.Add(slot23);

            Slot slot24 = new Slot();

            slot24.PosicionTorre =
                new Vector2(660, 470);

            slot24.AreaConstruccion =
                new Rectangle(
                    660,
                    487,
                    90,
                    73
                );

            slot24.TorreColocada = false;

            slots.Add(slot24);

            Slot slot25 = new Slot();

            slot25.PosicionTorre =
                new Vector2(800, 470);

            slot25.AreaConstruccion =
                new Rectangle(
                    800,
                    487,
                    90,
                    73
                );

            slot25.TorreColocada = false;

            slots.Add(slot25);

            Slot slot26 = new Slot();

            slot26.PosicionTorre =
                new Vector2(946, 470);

            slot26.AreaConstruccion =
                new Rectangle(
                    946,
                    487,
                    90,
                    73
                );

            slot26.TorreColocada = false;

            slots.Add(slot26);

            Slot slot27 = new Slot();

            slot27.PosicionTorre =
                new Vector2(295, 378);

            slot27.AreaConstruccion =
                new Rectangle(
                    295,
                    398,
                    90,
                    73
                );

            slot27.TorreColocada = false;

            slots.Add(slot27);

            Slot slot28 = new Slot();

            slot28.PosicionTorre =
                new Vector2(285, 475);

            slot28.AreaConstruccion =
                new Rectangle(
                    285,
                    490,
                    90,
                    73
                );

            slot28.TorreColocada = false;

            slots.Add(slot28);

            Slot slot29 = new Slot();

            slot29.PosicionTorre =
                new Vector2(405, 475);

            slot29.AreaConstruccion =
                new Rectangle(
                    405,
                    490,
                    90,
                    73
                );

            slot29.TorreColocada = false;

            slots.Add(slot29);

            Slot slot30 = new Slot();

            slot30.PosicionTorre =
                new Vector2(285, 560);

            slot30.AreaConstruccion =
                new Rectangle(
                    285,
                    578,
                    90,
                    73
                );

            slot30.TorreColocada = false;

            slots.Add(slot30);

            Slot slot31 = new Slot();

            slot31.PosicionTorre =
                new Vector2(508, 640);

            slot31.AreaConstruccion =
                new Rectangle(
                    508,
                    660,
                    90,
                    73
                );

            slot31.TorreColocada = false;

            slots.Add(slot31);

            Slot slot32 = new Slot();

            slot32.PosicionTorre =
                new Vector2(635, 640);

            slot32.AreaConstruccion =
                new Rectangle(
                    635,
                    660,
                    90,
                    73
                );

            slot32.TorreColocada = false;

            slots.Add(slot32);

            Slot slot33 = new Slot();

            slot33.PosicionTorre =
                new Vector2(752, 640);

            slot33.AreaConstruccion =
                new Rectangle(
                    752,
                    660,
                    90,
                    73
                );

            slot33.TorreColocada = false;

            slots.Add(slot33);

            Slot slot34 = new Slot();

            slot34.PosicionTorre =
                new Vector2(872, 640);

            slot34.AreaConstruccion =
                new Rectangle(
                    872,
                    660,
                    90,
                    73
                );

            slot34.TorreColocada = false;

            slots.Add(slot34);

            Slot slot35 = new Slot();

            slot35.PosicionTorre =
                new Vector2(992, 640);

            slot35.AreaConstruccion =
                new Rectangle(
                    992,
                    660,
                    90,
                    73
                );

            slot35.TorreColocada = false;

            slots.Add(slot35);

            Slot slot36 = new Slot();

            slot36.PosicionTorre =
                new Vector2(1192, 640);

            slot36.AreaConstruccion =
                new Rectangle(
                    1192,
                    660,
                    90,
                    73
                );

            slot36.TorreColocada = false;

            slots.Add(slot36);

            Slot slot37 = new Slot();

            slot37.PosicionTorre =
                new Vector2(1337, 500);

            slot37.AreaConstruccion =
                new Rectangle(
                    1337,
                    520,
                    90,
                    73
                );

            slot37.TorreColocada = false;

            slots.Add(slot37);

            Slot slot38 = new Slot();

            slot38.PosicionTorre =
                new Vector2(1415, 680);

            slot38.AreaConstruccion =
                new Rectangle(
                    1415,
                    700,
                    90,
                    73
                );

            slot38.TorreColocada = false;

            slots.Add(slot38);

            return slots;
        }
    }
}