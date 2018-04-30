CREATE TABLE `Crops` (
	`Id`	TEXT NOT NULL UNIQUE,
	`Runner`	TEXT NOT NULL,
	`Submitter`	TEXT NOT NULL,
	`SubmittedOn`	TEXT,
	`GameCropTop`	INTEGER NOT NULL,
	`GameCropLeft`	INTEGER NOT NULL,
	`GameCropBottom`	INTEGER NOT NULL,
	`GameCropRight`	INTEGER NOT NULL,
	`TimerCropTop`	INTEGER NOT NULL,
	`TimerCropLeft`	INTEGER NOT NULL,
	`TimerCropBottom`	INTEGER NOT NULL,
	`TimerCropRight`	INTEGER NOT NULL,
	`SizeWidth`	INTEGER NOT NULL,
	`SizeHeight`	INTEGER NOT NULL,
	PRIMARY KEY(`Id`)
);
CREATE INDEX `idx_runner` ON `Crops` (
	`Runner`	ASC,
	`Submitter`	ASC
);