/*
 Navicat Premium Data Transfer

 Source Server         : ZQY
 Source Server Type    : MySQL
 Source Server Version : 50723
 Source Host           : localhost:3306
 Source Schema         : zqy

 Target Server Type    : MySQL
 Target Server Version : 50723
 File Encoding         : 65001

 Date: 11/01/2019 17:37:13
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for identityrole
-- ----------------------------
DROP TABLE IF EXISTS `identityrole`;
CREATE TABLE `identityrole`  (
  `OrganizationId` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Id` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `Discriminator` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `IsDeleted` bit(1) NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `NormalizedName` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Type` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `RoleNameIndex`(`NormalizedName`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of identityrole
-- ----------------------------
INSERT INTO `identityrole` VALUES ('1', '069d0865-02b4-488b-8446-acb1fe956751', '5077d157-8a4e-41e3-a3b2-da22b0e51d2e', 'Roles', b'0', '事业部经理', '事业部经理', 'Public');
INSERT INTO `identityrole` VALUES ('f28f1c49-ac2f-4871-9145-ac0b4517ec2d', '106a1f98-741f-4cf1-9b2d-44603229df8b', '71b9b351-ea04-477e-a205-cb0d3782b971', 'Roles', b'0', '测试权限角色', '测试权限角色', 'Normal');
INSERT INTO `identityrole` VALUES ('1', '29fd3242-696c-4eae-aca0-4c2a3a56c1f6', 'eca396a8-a5e4-4bf0-82e9-bab344e0375d', 'Roles', b'0', '销售秘书', '销售秘书', 'Public');
INSERT INTO `identityrole` VALUES ('1', '2f0c33db-60e5-42c1-8aa8-925b5a87deb7', '51fe66c6-0973-46fc-89a0-0180ad64477b', 'Roles', b'0', '系统管理员', '系统管理员', 'Normal');
INSERT INTO `identityrole` VALUES ('1', '4594432f-3e40-4d8c-8de5-6e9f1ec6832e', 'e225f018-5f7e-4afc-b36c-46d42da5147a', 'Roles', b'0', '组织人员查询', '组织人员查询', 'Normal');
INSERT INTO `identityrole` VALUES ('6a50c88e-a53f-46df-9314-469b5de5a555', '47e6c316-e034-443d-b6bf-6975a7fb0057', '40beb45a-f4ce-4926-8c6b-dbac3acb8f45', 'Roles', b'0', '广告管理员', '广告管理员', 'Public');
INSERT INTO `identityrole` VALUES ('1', '48b44585-dfcc-4c8e-b549-6c4dbbf8cd35', '5679c9a3-8cdd-447b-a71d-fc008221898b', 'Roles', b'0', '外联专员', '外联专员', 'Public');
INSERT INTO `identityrole` VALUES ('1', '5272aaa4-47c0-4434-b493-5afb8c74683e', '80719261-8fdb-4d90-a11e-f6b93e772e6a', 'Roles', b'0', '房源采集员', '房源采集员', 'Public');
INSERT INTO `identityrole` VALUES ('1', '532ee368-2520-4d8c-96bc-c1498bc07c05', 'e337622f-0b28-4fc6-9a0b-9924885e1e9c', 'Roles', b'0', '项目总监', '项目总监', 'Public');
INSERT INTO `identityrole` VALUES ('1', '6693bdc9-12a3-45f5-ba0d-279e32ea77f2', 'd4dca634-5693-4be7-9f89-88e3d3ab9cf5', 'Roles', b'0', '城市总经理', '城市总经理', 'Public');
INSERT INTO `identityrole` VALUES ('1', '66cf4026-3b5f-44cf-9e3a-f726dcff19ec', '89812935-cba4-49ff-9970-490f4476c2e7', 'Roles', b'0', '风控中心', '风控中心', 'Public');
INSERT INTO `identityrole` VALUES ('6a50c88e-a53f-46df-9314-469b5de5a555', '69495318-9d48-4207-99f1-5600226b593d', '48252404-cca7-4ce6-86d5-d7d1f6dc44e5', 'Roles', b'0', '浏览广告', '浏览广告', 'Public');
INSERT INTO `identityrole` VALUES ('1', '6b461e3a-0565-44c4-8253-49c41fd00f3d', '4c36794e-6234-4e93-a236-b9864357f62d', 'Roles', b'0', '驻场专员', '驻场专员', 'Public');
INSERT INTO `identityrole` VALUES ('1', '6c261bc1-961c-4c4c-8a04-5031ba9cd2cb', '688247a5-dd9c-420b-a5fe-cc2842a83bfa', 'Roles', b'0', '运营部经理', '运营部经理', 'Public');
INSERT INTO `identityrole` VALUES ('597282c8-6714-4333-aca6-f12c4c8ba3a5', '7432a1dd-6acc-4a84-a66e-6fdf407d867d', 'd7178720-1e10-4795-ba24-dcb9929e4aaf', 'Roles', b'0', '总经理助理', '总经理助理', 'Public');
INSERT INTO `identityrole` VALUES ('1', '744ef098-794c-4c94-b3e6-71b3220b5de6', NULL, NULL, b'0', '老板', NULL, NULL);
INSERT INTO `identityrole` VALUES ('1', '7c259237-057a-4a48-8f69-60a58a487bb3', '39840d3d-03cc-447b-89de-b991e4d77cee', 'Roles', b'0', '经纪公司管理员', '经纪公司管理员', 'Public');
INSERT INTO `identityrole` VALUES ('1', '89c22022-52d3-4727-971f-dc03bb634a5c', '958ec8b5-a629-4af7-9dfb-4fe44d8299ec', 'Roles', b'0', '开发商管理员', '开发商管理员', 'Public');
INSERT INTO `identityrole` VALUES ('1', 'a6323fa3-482f-4e6b-8fad-4f4caf3dafc9', 'dcd3159c-9238-4e11-88e6-da3ddbed8693', 'Roles', b'0', '总裁', '总裁', 'Public');
INSERT INTO `identityrole` VALUES ('b03129f0-fc88-4cee-ba5a-cb626a8f89f2', 'acace806-52ca-4b3f-ae0d-450944cb3288', 'a48170ea-5365-41f1-a030-ef3544b7874e', 'Roles', b'0', '员工账号管理', '员工账号管理', 'Normal');
INSERT INTO `identityrole` VALUES ('d6d9ae8e-2f74-4053-9888-affafd11dffb', 'aff1d7ed-ea2c-4101-b70e-75b17f38abe5', NULL, NULL, b'0', '老板22222222222', NULL, NULL);
INSERT INTO `identityrole` VALUES ('1', 'c98b804e-4f63-4e44-b39a-b7f5ebab7b70', 'd7117e65-c412-4a06-a885-a7834e5707a1', 'Roles', b'0', '数据运营总监', '数据运营总监', 'Public');
INSERT INTO `identityrole` VALUES ('1', 'd229723c-9e52-46c7-afd9-820c91813713', '4d2453e9-2985-4ee3-bbd4-fd0668ca02ae', 'Roles', b'0', '运营中心', '运营中心', 'Public');
INSERT INTO `identityrole` VALUES ('de4b5e21-61e1-4854-8a18-5e89bd070bd1', 'eb5d6ebb-7a1b-41d6-a80c-1653e1005c17', '19dd5ca0-2d49-41ce-b72f-ae1a584712b7', 'Roles', b'0', '技术部管理员', '技术部管理员', 'Normal');
INSERT INTO `identityrole` VALUES ('1', 'ef60a5b9-3988-433d-93c7-e18d0c79ba68', 'b28bdaa2-be44-410c-ad10-5c8e799a6051', 'Roles', b'0', '董事长', '董事长', 'Public');
INSERT INTO `identityrole` VALUES ('1', 'f15287a5-f05c-4f8e-9769-94f30d61f3fe', '4e5a808a-0434-4a46-8104-81f5e7e6c3ec', 'Roles', b'0', '基本角色', '基本角色', 'Normal');
INSERT INTO `identityrole` VALUES ('0', 'f8e52937f7e846eaa95884e66adccd2e', 'de247ba5-d7ea-453a-bc19-c38abb8cc48e', 'Roles', b'0', 'admin', 'ADMIN', 'Normal');
INSERT INTO `identityrole` VALUES ('1', 'fb020b36-a370-4928-9f3c-b3b3d79e1292', '77b836fa-90b8-4200-97bc-54b171f7d719', 'Roles', b'0', '环境切换', '环境切换', 'Normal');

-- ----------------------------
-- Table structure for identityuser
-- ----------------------------
DROP TABLE IF EXISTS `identityuser`;
CREATE TABLE `identityuser`  (
  `Avatar` varchar(512) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `FilialeId` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `OrganizationId` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `TrueName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `WXOpenId` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Id` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `AccessFailedCount` int(11) NULL DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `Discriminator` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `EmailConfirmed` bit(1) NULL DEFAULT NULL,
  `IsDeleted` bit(1) NOT NULL,
  `LockoutEnabled` bit(1) NULL DEFAULT NULL,
  `LockoutEnd` datetime(6) NULL DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `NormalizedUserName` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `PhoneNumberConfirmed` bit(1) NULL DEFAULT NULL,
  `SecurityStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `TwoFactorEnabled` bit(1) NULL DEFAULT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Position` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `DeleteTime` datetime(0) NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP(0),
  `DeleteUser` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP(0),
  `CreateUser` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `ParentId` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `IsDisplay` bit(1) NULL DEFAULT b'1',
  `QQ` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT 'QQ',
  `Wechat` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '微信',
  `JobNumber` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '工号',
  `Sex` bit(1) NULL DEFAULT NULL COMMENT '性别',
  `PinYin` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT '姓名首字母',
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `UserNameIndex`(`NormalizedUserName`) USING BTREE,
  INDEX `EmailIndex`(`NormalizedEmail`(191)) USING BTREE,
  INDEX `IDX_IDENTITYUSER_ORG`(`OrganizationId`) USING BTREE,
  INDEX `IDX_IDENTITYUSER_ID`(`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of identityuser
-- ----------------------------
INSERT INTO `identityuser` VALUES ('0', '0', '4cba486f-a98e-4d95-8746-551304bbae03', '张三', '1', '1', 1, '1', '1', '1', b'1', b'0', b'1', '2018-12-14 13:56:25.000000', '1', '1', '1', '13167874692', b'1', '1', b'1', '1', '1', '2018-12-25 15:31:36', '1', '2018-12-25 15:31:36', '1', '1', b'1', '2536156085', '1', '1', b'1', '1');
INSERT INTO `identityuser` VALUES (NULL, '1', '1', '李四', NULL, '2', 1, '1', '1', '1', b'1', b'0', b'1', NULL, '2', '2', '2', '18755554820', b'1', '2', b'1', '2', '2', '2018-12-19 20:58:37', '1', '2018-12-19 20:58:37', '1', '1', b'1', '2536156085', '1', '1', b'1', '1');
INSERT INTO `identityuser` VALUES (NULL, NULL, 'd132fcd8-5d44-46f1-a1d6-deee3983218c', '张饥饿', NULL, '65d534cc-af6a-439d-821c-9e4bbf03014e', NULL, NULL, NULL, NULL, NULL, b'0', NULL, NULL, NULL, NULL, '123456', '15167874692', NULL, NULL, NULL, 'er', NULL, NULL, NULL, '2019-01-11 17:00:13', NULL, NULL, b'1', NULL, NULL, NULL, b'0', NULL);
INSERT INTO `identityuser` VALUES (NULL, NULL, '0', '郑强勇', NULL, 'ab2c7f05-9b75-4016-b982-42db3099ea07', NULL, NULL, NULL, NULL, NULL, b'0', NULL, NULL, NULL, NULL, '123456', '13167874692', NULL, NULL, NULL, 'zqy', NULL, NULL, NULL, '2018-12-26 11:14:16', NULL, NULL, b'1', NULL, NULL, NULL, b'1', NULL);
INSERT INTO `identityuser` VALUES (NULL, NULL, '1', '郑强勇', NULL, 'ccc0d570-0901-47c6-8e6e-380e8668246e', NULL, NULL, NULL, NULL, NULL, b'0', NULL, NULL, NULL, NULL, '123456', '13167874692', NULL, NULL, NULL, 'zqy', NULL, NULL, NULL, '2018-12-26 11:15:49', NULL, NULL, b'1', NULL, NULL, NULL, b'1', NULL);

-- ----------------------------
-- Table structure for organizationexpansions
-- ----------------------------
DROP TABLE IF EXISTS `organizationexpansions`;
CREATE TABLE `organizationexpansions`  (
  `OrganizationId` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `SonId` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `OrganizationName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `SonName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `IsImmediate` bit(1) NOT NULL,
  `Type` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `City` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `FullName` varchar(1024) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`OrganizationId`, `SonId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of organizationexpansions
-- ----------------------------
INSERT INTO `organizationexpansions` VALUES ('0', '00326161-60c3-4db9-9283-fce99fa5ecd9', '默认顶级', 'q111', b'0', '', '', '默认顶级-交通部-q111');
INSERT INTO `organizationexpansions` VALUES ('0', '1', '默认顶级', '总部', b'1', '', '', '默认顶级-总部');
INSERT INTO `organizationexpansions` VALUES ('0', '2101cfe4-60c7-472d-99c5-65a041705eb4', '默认顶级', '111', b'0', NULL, NULL, '默认顶级-');
INSERT INTO `organizationexpansions` VALUES ('0', '30a98f89-0a85-4fc1-87ea-c27638d1b5e8', '默认顶级', '新空间', b'0', '', '', '默认顶级-总部-风控中心-新空间');
INSERT INTO `organizationexpansions` VALUES ('0', '33b48f69-96c5-454f-94c9-a865034144a5', '默认顶级', '人力行政中心', b'0', '', '', '默认顶级-总部-人力行政中心');
INSERT INTO `organizationexpansions` VALUES ('0', '34b90a34-a8c2-44e7-be2f-5fa056414491', '默认顶级', '啊啊啊', b'0', '', '', '默认顶级-交通部-啊啊啊');
INSERT INTO `organizationexpansions` VALUES ('0', '384c66df-b97e-430c-bdd4-8e9cd84d8ef7', '默认顶级', '交通', b'0', '', '', '默认顶级-交通部-交通');
INSERT INTO `organizationexpansions` VALUES ('0', '3b58adf3-bb61-4215-9ca7-453e09365082', '默认顶级', '重庆分公司', b'0', '', '', '默认顶级-总部-营销运营中心-重庆分公司');
INSERT INTO `organizationexpansions` VALUES ('0', '3d3d331b-c481-4cd0-b796-aebe49ecc8b9', '默认顶级', '财务部', b'0', '', '', '默认顶级-总部-营销运营中心-重庆分公司-财务部');
INSERT INTO `organizationexpansions` VALUES ('0', '3d41347c-2262-40f9-821a-e7bc9bebb177', '默认顶级', 'asdadsad', b'0', NULL, NULL, '默认顶级-');
INSERT INTO `organizationexpansions` VALUES ('0', '43585f44-9b39-4f88-ace6-ccda02ae7200', '默认顶级', '后勤', b'0', '', '', '默认顶级-交通部-交通-后勤');
INSERT INTO `organizationexpansions` VALUES ('0', '46b3e5a9-da45-438b-8e32-a9a935098a1e', '默认顶级', '产品组', b'0', '', '', '默认顶级-总部-产品设计部-产品组');
INSERT INTO `organizationexpansions` VALUES ('0', '507be2c5-171a-4b36-9b95-02560330258d', '默认顶级', '质量保障部', b'0', '', '', '默认顶级-总部-技术研发中心-质量保障部');
INSERT INTO `organizationexpansions` VALUES ('0', '54ddd090-5e69-447f-8b34-cd0880bb5095', '默认顶级', '建部门', b'0', '', '', '默认顶级-总部-风控中心-建部门');
INSERT INTO `organizationexpansions` VALUES ('0', '56834ed4-5f38-481f-b1b2-232aed76fed3', '默认顶级', 'UI组', b'0', '', '', '默认顶级-总部-产品设计部-UI组');
INSERT INTO `organizationexpansions` VALUES ('0', '56d8f9a1-f4b7-46de-9a21-31df94936a18', '默认顶级', '南区', b'0', '', '', '默认顶级-总部-营销运营中心-重庆分公司-事业部-南区');
INSERT INTO `organizationexpansions` VALUES ('0', '597282c8-6714-4333-aca6-f12c4c8ba3a5', '默认顶级', '总裁室', b'0', '', '', '默认顶级-总部-总裁室');
INSERT INTO `organizationexpansions` VALUES ('0', '5d365311-187f-43dc-a727-c03eee845878', '默认顶级', '拓展部', b'0', '', '', '默认顶级-总部-营销运营中心-成都分公司-拓展部');
INSERT INTO `organizationexpansions` VALUES ('0', '608374ba-ed02-4d2a-904f-062918233d3d', '默认顶级', '西区', b'0', '', '', '默认顶级-总部-营销运营中心-重庆分公司-事业部-西区');
INSERT INTO `organizationexpansions` VALUES ('0', '663974d3-ee55-4e36-84c0-8da5da98deb9', '默认顶级', '北区', b'0', '', '', '默认顶级-总部-营销运营中心-重庆分公司-事业部-北区');
INSERT INTO `organizationexpansions` VALUES ('0', '6a50c88e-a53f-46df-9314-469b5de5a555', '默认顶级', '数据运营中心', b'0', '', '', '默认顶级-总部-数据运营中心');
INSERT INTO `organizationexpansions` VALUES ('0', '6b60d3b4-690b-4e6f-bea7-eb1f101913b1', '默认顶级', '审计组', b'0', '', '', '默认顶级-总部-风控中心-审计组');
INSERT INTO `organizationexpansions` VALUES ('0', '6bc64ed3-ccf8-49f5-83d6-aa45392febb9', '默认顶级', '金控组', b'0', '', '', '默认顶级-总部-风控中心-金控组');
INSERT INTO `organizationexpansions` VALUES ('0', '6cc1f3fc-245b-4f24-8eb2-2f0115152f5f', '默认顶级', '财务中心', b'0', '', '', '默认顶级-总部-财务中心');
INSERT INTO `organizationexpansions` VALUES ('0', '70a943af-fd33-48a4-8e87-0aafbeb5dce1', '默认顶级', '风控中心', b'0', '', '', '默认顶级-总部-风控中心');
INSERT INTO `organizationexpansions` VALUES ('0', '70d7304d-7b79-4e30-b400-1a9bdc65d123', '默认顶级', '对外合作部', b'0', '', '', '默认顶级-总部-数据运营中心-对外合作部');
INSERT INTO `organizationexpansions` VALUES ('0', '80a09984-6714-442c-8927-b75dc3202e62', '默认顶级', '南区', b'0', '', '', '默认顶级-总部-营销运营中心-成都分公司-事业部-南区');
INSERT INTO `organizationexpansions` VALUES ('0', '846fe421-dfb7-491c-b4a8-940b1257f27c', '默认顶级', '拓展部', b'0', '', '', '默认顶级-总部-营销运营中心-重庆分公司-拓展部');
INSERT INTO `organizationexpansions` VALUES ('0', '85751dab-3e9b-4c16-a09d-0427c3d11983', '默认顶级', '会计与税务组', b'0', '', '', '默认顶级-总部-财务中心-会计与税务组');
INSERT INTO `organizationexpansions` VALUES ('0', '871fd1ac-bfb6-4dd1-b8fd-f78b4e9ffecb', '默认顶级', '数据分析部', b'0', '', '', '默认顶级-总部-数据运营中心-数据分析部');
INSERT INTO `organizationexpansions` VALUES ('0', '8777f829-ea1e-48ee-9685-a68b0f98583e', '默认顶级', '成都分公司', b'0', '', '', '默认顶级-总部-营销运营中心-成都分公司');
INSERT INTO `organizationexpansions` VALUES ('0', '8ac1b28b-3fbd-4907-b44d-89d4bebd46ee', '默认顶级', '人力资源组', b'0', '', '', '默认顶级-总部-人力行政中心-人力资源组');
INSERT INTO `organizationexpansions` VALUES ('0', '96d01ba2-79fd-493c-b0af-abc907d41c06', '默认顶级', '法务组', b'0', '', '', '默认顶级-总部-风控中心-法务组');
INSERT INTO `organizationexpansions` VALUES ('0', '9dce0dca-3876-46f8-8d12-6a6eca4fe50b', '默认顶级', '工商管理部', b'0', '', '', '默认顶级-总部-工商管理部');
INSERT INTO `organizationexpansions` VALUES ('0', 'a02b751f-c6d5-4649-88b1-d967f9829717', '默认顶级', '北区', b'0', '', '', '默认顶级-总部-营销运营中心-成都分公司-事业部-南区-北区');
INSERT INTO `organizationexpansions` VALUES ('0', 'a6590cbf-a252-4532-aa16-012a96f170cc', '默认顶级', '啊啊', b'0', '', '', '默认顶级-交通部-啊啊啊-啊啊');
INSERT INTO `organizationexpansions` VALUES ('0', 'a9b856e3-5925-4198-8e24-5606455d02ac', '默认顶级', '财务部', b'0', '', '', '默认顶级-总部-营销运营中心-成都分公司-财务部');
INSERT INTO `organizationexpansions` VALUES ('0', 'acb19cf0-0897-4d1c-9079-34a60d06407e', '默认顶级', '营销运营中心', b'0', '', '', '默认顶级-总部-营销运营中心');
INSERT INTO `organizationexpansions` VALUES ('0', 'b03129f0-fc88-4cee-ba5a-cb626a8f89f2', '默认顶级', 'IT技术支持', b'0', NULL, NULL, '默认顶级-');
INSERT INTO `organizationexpansions` VALUES ('0', 'b62f025a-eeaa-4bb9-9ecf-e8068e84f7de', '默认顶级', '后端组', b'0', '', '', '默认顶级-总部-技术研发中心-应用研发部-后端组');
INSERT INTO `organizationexpansions` VALUES ('0', 'b9109ece-d390-4673-9d08-857d184c2aab', '默认顶级', '行政组', b'0', '', '', '默认顶级-总部-人力行政中心-行政组');
INSERT INTO `organizationexpansions` VALUES ('0', 'bda28aeb-8403-4a6d-af3e-5a1b88bfdbb1', '默认顶级', '交通部', b'1', '', '', '默认顶级-交通部');
INSERT INTO `organizationexpansions` VALUES ('0', 'be042d04-9519-45e9-bb40-24049ea7c967', '默认顶级', '基础服务部', b'0', '', '', '默认顶级-总部-技术研发中心-基础服务部');
INSERT INTO `organizationexpansions` VALUES ('0', 'bf2ceeff-fd7e-472d-94c2-9404f88dced0', '默认顶级', '后台部', b'1', '', '', '默认顶级-后台部');
INSERT INTO `organizationexpansions` VALUES ('0', 'c104b5d3-65df-4f64-a310-7b46d5b57b3f', '默认顶级', '嗷嗷嗷', b'0', '', '', '默认顶级-交通部-嗷嗷嗷');
INSERT INTO `organizationexpansions` VALUES ('0', 'ca7d6f90-4d37-4f7e-bf08-c5a4338a1f91', '默认顶级', '事业部', b'0', '', '', '默认顶级-总部-营销运营中心-成都分公司-事业部');
INSERT INTO `organizationexpansions` VALUES ('0', 'cb12edc3-7489-471d-b976-73bbfd1b6277', '默认顶级', 'Web组', b'0', '', '', '默认顶级-总部-技术研发中心-应用研发部-Web组');
INSERT INTO `organizationexpansions` VALUES ('0', 'cd5677ae-0841-4027-89c0-4654a853a8ec', '默认顶级', '测试部门', b'0', NULL, NULL, '默认顶级-');
INSERT INTO `organizationexpansions` VALUES ('0', 'ce5e5b5d-076a-451d-a3ea-503ce1b2f5b9', '默认顶级', '工具研发组', b'0', '', '', '默认顶级-总部-技术研发中心-基础服务部-工具研发组');
INSERT INTO `organizationexpansions` VALUES ('0', 'ceacb8f6-b713-457d-bce5-bb40360f190a', '默认顶级', '事业部', b'0', '', '', '默认顶级-总部-营销运营中心-重庆分公司-事业部');
INSERT INTO `organizationexpansions` VALUES ('0', 'cedcf386-fe6a-4f27-a11c-cef0b19c3956', '默认顶级', '产品设计部', b'0', '', '', '默认顶级-总部-产品设计部');
INSERT INTO `organizationexpansions` VALUES ('0', 'd1f58a08-e9b2-4f6a-9241-2c48f6dab414', '默认顶级', '资金结算组', b'0', '', '', '默认顶级-总部-财务中心-资金结算组');
INSERT INTO `organizationexpansions` VALUES ('0', 'd3825c1b-4060-4a17-a920-c94055548784', '默认顶级', '人力行政部', b'0', '', '', '默认顶级-总部-营销运营中心-重庆分公司-人力行政部');
INSERT INTO `organizationexpansions` VALUES ('0', 'de4b5e21-61e1-4854-8a18-5e89bd070bd1', '默认顶级', '技术研发中心', b'0', '', '', '默认顶级-总部-技术研发中心');
INSERT INTO `organizationexpansions` VALUES ('0', 'e169e1ac-c6c6-4d91-8a32-6a93b093580d', '默认顶级', '财政部', b'1', '', '', '默认顶级-财政部');
INSERT INTO `organizationexpansions` VALUES ('0', 'e5768524-dc68-4a47-bf2a-68834258a375', '默认顶级', '应用研发部', b'0', '', '', '默认顶级-总部-技术研发中心-应用研发部');
INSERT INTO `organizationexpansions` VALUES ('0', 'e590fbd0-ca40-479c-8f01-7a0d4c13940b', '默认顶级', '客服部', b'0', '', '', '默认顶级-总部-数据运营中心-客服部');
INSERT INTO `organizationexpansions` VALUES ('0', 'e771e1a9-e47a-4805-a10c-09e2c2b16aed', '默认顶级', '运营部', b'0', '', '', '默认顶级-总部-数据运营中心-运营部');
INSERT INTO `organizationexpansions` VALUES ('0', 'e891ee7f-348d-4de0-a53a-2ba09d4261c5', '默认顶级', '测试运维组', b'0', '', '', '默认顶级-总部-技术研发中心-基础服务部-测试运维组');
INSERT INTO `organizationexpansions` VALUES ('0', 'eabb8bea-0b32-409c-bfad-cd47e44a3b54', '默认顶级', '财务管理与内控组', b'0', '', '', '默认顶级-总部-财务中心-财务管理与内控组');
INSERT INTO `organizationexpansions` VALUES ('0', 'ef4db299-404f-41be-8617-54f2cfe29231', '默认顶级', '大数据组', b'0', '', '', '默认顶级-总部-技术研发中心-基础服务部-大数据组');
INSERT INTO `organizationexpansions` VALUES ('0', 'f06cf42b-d5ca-4eca-b3d2-1f5edbd7110d', '默认顶级', '移动组', b'0', '', '', '默认顶级-总部-技术研发中心-应用研发部-移动组');
INSERT INTO `organizationexpansions` VALUES ('0', 'f34a6dfd-4938-4c18-bc83-ee1166a95161', '默认顶级', '策划部', b'0', '', '', '默认顶级-总部-营销运营中心-重庆分公司-策划部');
INSERT INTO `organizationexpansions` VALUES ('0', 'f5db9c5b-d065-4611-9337-09b7f356d048', '默认顶级', '招商运营部', b'0', '', '', '默认顶级-总部-营销运营中心-重庆分公司-招商运营部');
INSERT INTO `organizationexpansions` VALUES ('0', 'f75e1275-b27a-454a-9e9e-987fdf738e0e', '默认顶级', '地方烦烦烦烦烦烦烦烦烦烦烦烦', b'0', '', '', '默认顶级-交通部-wwww');
INSERT INTO `organizationexpansions` VALUES ('0', 'febab76a-8a44-4eff-851c-470263f6b697', '默认顶级', '656565', b'0', NULL, NULL, '默认顶级-');
INSERT INTO `organizationexpansions` VALUES ('0', 'ff37c09e-622f-4d6b-8a5e-db734d3da562', '默认顶级', '系统架构师', b'0', '', '', '默认顶级-总部-技术研发中心-基础服务部-系统架构师');
INSERT INTO `organizationexpansions` VALUES ('1', '2101cfe4-60c7-472d-99c5-65a041705eb4', '总部', '111', b'0', 'Bloc', '500000', '默认顶级-总部-测试部门-');
INSERT INTO `organizationexpansions` VALUES ('1', '30a98f89-0a85-4fc1-87ea-c27638d1b5e8', '总部', '新空间', b'0', 'Bloc', '500000', '总部-风控中心-新空间');
INSERT INTO `organizationexpansions` VALUES ('1', '33b48f69-96c5-454f-94c9-a865034144a5', '总部', '人力行政中心', b'1', 'Bloc', '500000', '总部-人力行政中心');
INSERT INTO `organizationexpansions` VALUES ('1', '3b58adf3-bb61-4215-9ca7-453e09365082', '总部', '重庆分公司', b'0', 'Bloc', '500000', '总部-营销运营中心-重庆分公司');
INSERT INTO `organizationexpansions` VALUES ('1', '3d3d331b-c481-4cd0-b796-aebe49ecc8b9', '总部', '财务部', b'0', 'Bloc', '500000', '总部-营销运营中心-重庆分公司-财务部');
INSERT INTO `organizationexpansions` VALUES ('1', '46b3e5a9-da45-438b-8e32-a9a935098a1e', '总部', '产品组', b'0', 'Bloc', '500000', '总部-产品设计部-产品组');
INSERT INTO `organizationexpansions` VALUES ('1', '507be2c5-171a-4b36-9b95-02560330258d', '总部', '质量保障部', b'0', 'Bloc', '500000', '总部-技术研发中心-质量保障部');
INSERT INTO `organizationexpansions` VALUES ('1', '54ddd090-5e69-447f-8b34-cd0880bb5095', '总部', '建部门', b'0', 'Bloc', '500000', '总部-风控中心-建部门');
INSERT INTO `organizationexpansions` VALUES ('1', '56834ed4-5f38-481f-b1b2-232aed76fed3', '总部', 'UI组', b'0', 'Bloc', '500000', '总部-产品设计部-UI组');
INSERT INTO `organizationexpansions` VALUES ('1', '56d8f9a1-f4b7-46de-9a21-31df94936a18', '总部', '南区', b'0', 'Bloc', '500000', '总部-营销运营中心-重庆分公司-事业部-南区');
INSERT INTO `organizationexpansions` VALUES ('1', '597282c8-6714-4333-aca6-f12c4c8ba3a5', '总部', '总裁室', b'1', 'Bloc', '500000', '总部-总裁室');
INSERT INTO `organizationexpansions` VALUES ('1', '5d365311-187f-43dc-a727-c03eee845878', '总部', '拓展部', b'0', 'Bloc', '500000', '总部-营销运营中心-成都分公司-拓展部');
INSERT INTO `organizationexpansions` VALUES ('1', '608374ba-ed02-4d2a-904f-062918233d3d', '总部', '西区', b'0', 'Bloc', '500000', '总部-营销运营中心-重庆分公司-事业部-西区');
INSERT INTO `organizationexpansions` VALUES ('1', '663974d3-ee55-4e36-84c0-8da5da98deb9', '总部', '北区', b'0', 'Bloc', '500000', '总部-营销运营中心-重庆分公司-事业部-北区');
INSERT INTO `organizationexpansions` VALUES ('1', '6a50c88e-a53f-46df-9314-469b5de5a555', '总部', '数据运营中心', b'1', 'Bloc', '500000', '总部-数据运营中心');
INSERT INTO `organizationexpansions` VALUES ('1', '6b60d3b4-690b-4e6f-bea7-eb1f101913b1', '总部', '审计组', b'0', 'Bloc', '500000', '总部-风控中心-审计组');
INSERT INTO `organizationexpansions` VALUES ('1', '6bc64ed3-ccf8-49f5-83d6-aa45392febb9', '总部', '金控组', b'0', 'Bloc', '500000', '总部-风控中心-金控组');
INSERT INTO `organizationexpansions` VALUES ('1', '6cc1f3fc-245b-4f24-8eb2-2f0115152f5f', '总部', '财务中心', b'1', 'Bloc', '500000', '总部-财务中心');
INSERT INTO `organizationexpansions` VALUES ('1', '70a943af-fd33-48a4-8e87-0aafbeb5dce1', '总部', '风控中心', b'1', 'Bloc', '500000', '总部-风控中心');
INSERT INTO `organizationexpansions` VALUES ('1', '70d7304d-7b79-4e30-b400-1a9bdc65d123', '总部', '对外合作部', b'0', 'Bloc', '500000', '总部-数据运营中心-对外合作部');
INSERT INTO `organizationexpansions` VALUES ('1', '80a09984-6714-442c-8927-b75dc3202e62', '总部', '南区', b'0', 'Bloc', '500000', '总部-营销运营中心-成都分公司-事业部-南区');
INSERT INTO `organizationexpansions` VALUES ('1', '846fe421-dfb7-491c-b4a8-940b1257f27c', '总部', '拓展部', b'0', 'Bloc', '500000', '总部-营销运营中心-重庆分公司-拓展部');
INSERT INTO `organizationexpansions` VALUES ('1', '85751dab-3e9b-4c16-a09d-0427c3d11983', '总部', '会计与税务组', b'0', 'Bloc', '500000', '总部-财务中心-会计与税务组');
INSERT INTO `organizationexpansions` VALUES ('1', '871fd1ac-bfb6-4dd1-b8fd-f78b4e9ffecb', '总部', '数据分析部', b'0', 'Bloc', '500000', '总部-数据运营中心-数据分析部');
INSERT INTO `organizationexpansions` VALUES ('1', '8777f829-ea1e-48ee-9685-a68b0f98583e', '总部', '成都分公司', b'0', 'Bloc', '500000', '总部-营销运营中心-成都分公司');
INSERT INTO `organizationexpansions` VALUES ('1', '8ac1b28b-3fbd-4907-b44d-89d4bebd46ee', '总部', '人力资源组', b'0', 'Bloc', '500000', '总部-人力行政中心-人力资源组');
INSERT INTO `organizationexpansions` VALUES ('1', '96d01ba2-79fd-493c-b0af-abc907d41c06', '总部', '法务组', b'0', 'Bloc', '500000', '总部-风控中心-法务组');
INSERT INTO `organizationexpansions` VALUES ('1', '9dce0dca-3876-46f8-8d12-6a6eca4fe50b', '总部', '工商管理部', b'1', 'Bloc', '500000', '总部-工商管理部');
INSERT INTO `organizationexpansions` VALUES ('1', 'a02b751f-c6d5-4649-88b1-d967f9829717', '总部', '北区', b'0', 'Bloc', '500000', '总部-营销运营中心-成都分公司-事业部-南区-北区');
INSERT INTO `organizationexpansions` VALUES ('1', 'a9b856e3-5925-4198-8e24-5606455d02ac', '总部', '财务部', b'0', 'Bloc', '500000', '总部-营销运营中心-成都分公司-财务部');
INSERT INTO `organizationexpansions` VALUES ('1', 'acb19cf0-0897-4d1c-9079-34a60d06407e', '总部', '营销运营中心', b'1', 'Bloc', '500000', '总部-营销运营中心');
INSERT INTO `organizationexpansions` VALUES ('1', 'b03129f0-fc88-4cee-ba5a-cb626a8f89f2', '总部', 'IT技术支持', b'0', 'Bloc', '500000', '默认顶级-总部-人力行政中心-行政组-');
INSERT INTO `organizationexpansions` VALUES ('1', 'b62f025a-eeaa-4bb9-9ecf-e8068e84f7de', '总部', '后端组', b'0', 'Bloc', '500000', '总部-技术研发中心-应用研发部-后端组');
INSERT INTO `organizationexpansions` VALUES ('1', 'b9109ece-d390-4673-9d08-857d184c2aab', '总部', '行政组', b'0', 'Bloc', '500000', '总部-人力行政中心-行政组');
INSERT INTO `organizationexpansions` VALUES ('1', 'be042d04-9519-45e9-bb40-24049ea7c967', '总部', '基础服务部', b'0', 'Bloc', '500000', '总部-技术研发中心-基础服务部');
INSERT INTO `organizationexpansions` VALUES ('1', 'ca7d6f90-4d37-4f7e-bf08-c5a4338a1f91', '总部', '事业部', b'0', 'Bloc', '500000', '总部-营销运营中心-成都分公司-事业部');
INSERT INTO `organizationexpansions` VALUES ('1', 'cb12edc3-7489-471d-b976-73bbfd1b6277', '总部', 'Web组', b'0', 'Bloc', '500000', '总部-技术研发中心-应用研发部-Web组');
INSERT INTO `organizationexpansions` VALUES ('1', 'cd5677ae-0841-4027-89c0-4654a853a8ec', '总部', '测试部门', b'1', 'Bloc', '500000', '默认顶级-总部-');
INSERT INTO `organizationexpansions` VALUES ('1', 'ce5e5b5d-076a-451d-a3ea-503ce1b2f5b9', '总部', '工具研发组', b'0', 'Bloc', '500000', '总部-技术研发中心-基础服务部-工具研发组');
INSERT INTO `organizationexpansions` VALUES ('1', 'ceacb8f6-b713-457d-bce5-bb40360f190a', '总部', '事业部', b'0', 'Bloc', '500000', '总部-营销运营中心-重庆分公司-事业部');
INSERT INTO `organizationexpansions` VALUES ('1', 'cedcf386-fe6a-4f27-a11c-cef0b19c3956', '总部', '产品设计部', b'1', 'Bloc', '500000', '总部-产品设计部');
INSERT INTO `organizationexpansions` VALUES ('1', 'd1f58a08-e9b2-4f6a-9241-2c48f6dab414', '总部', '资金结算组', b'0', 'Bloc', '500000', '总部-财务中心-资金结算组');
INSERT INTO `organizationexpansions` VALUES ('1', 'd3825c1b-4060-4a17-a920-c94055548784', '总部', '人力行政部', b'0', 'Bloc', '500000', '总部-营销运营中心-重庆分公司-人力行政部');
INSERT INTO `organizationexpansions` VALUES ('1', 'de4b5e21-61e1-4854-8a18-5e89bd070bd1', '总部', '技术研发中心', b'1', 'Bloc', '500000', '总部-技术研发中心');
INSERT INTO `organizationexpansions` VALUES ('1', 'e5768524-dc68-4a47-bf2a-68834258a375', '总部', '应用研发部', b'0', 'Bloc', '500000', '总部-技术研发中心-应用研发部');
INSERT INTO `organizationexpansions` VALUES ('1', 'e590fbd0-ca40-479c-8f01-7a0d4c13940b', '总部', '客服部', b'0', 'Bloc', '500000', '总部-数据运营中心-客服部');
INSERT INTO `organizationexpansions` VALUES ('1', 'e771e1a9-e47a-4805-a10c-09e2c2b16aed', '总部', '运营部', b'0', 'Bloc', '500000', '总部-数据运营中心-运营部');
INSERT INTO `organizationexpansions` VALUES ('1', 'e891ee7f-348d-4de0-a53a-2ba09d4261c5', '总部', '测试运维组', b'0', 'Bloc', '500000', '总部-技术研发中心-基础服务部-测试运维组');
INSERT INTO `organizationexpansions` VALUES ('1', 'eabb8bea-0b32-409c-bfad-cd47e44a3b54', '总部', '财务管理与内控组', b'0', 'Bloc', '500000', '总部-财务中心-财务管理与内控组');
INSERT INTO `organizationexpansions` VALUES ('1', 'ef4db299-404f-41be-8617-54f2cfe29231', '总部', '大数据组', b'0', 'Bloc', '500000', '总部-技术研发中心-基础服务部-大数据组');
INSERT INTO `organizationexpansions` VALUES ('1', 'f06cf42b-d5ca-4eca-b3d2-1f5edbd7110d', '总部', '移动组', b'0', 'Bloc', '500000', '总部-技术研发中心-应用研发部-移动组');
INSERT INTO `organizationexpansions` VALUES ('1', 'f34a6dfd-4938-4c18-bc83-ee1166a95161', '总部', '策划部', b'0', 'Bloc', '500000', '总部-营销运营中心-重庆分公司-策划部');
INSERT INTO `organizationexpansions` VALUES ('1', 'f5db9c5b-d065-4611-9337-09b7f356d048', '总部', '招商运营部', b'0', 'Bloc', '500000', '总部-营销运营中心-重庆分公司-招商运营部');
INSERT INTO `organizationexpansions` VALUES ('1', 'ff37c09e-622f-4d6b-8a5e-db734d3da562', '总部', '系统架构师', b'0', 'Bloc', '500000', '总部-技术研发中心-基础服务部-系统架构师');
INSERT INTO `organizationexpansions` VALUES ('33b48f69-96c5-454f-94c9-a865034144a5', '8ac1b28b-3fbd-4907-b44d-89d4bebd46ee', '人力行政中心', '人力资源组', b'1', 'Normal', '500000', '人力行政中心-人力资源组');
INSERT INTO `organizationexpansions` VALUES ('33b48f69-96c5-454f-94c9-a865034144a5', 'b03129f0-fc88-4cee-ba5a-cb626a8f89f2', '人力行政中心', 'IT技术支持', b'0', 'Normal', '500000', '默认顶级-人力行政中心-行政组-');
INSERT INTO `organizationexpansions` VALUES ('33b48f69-96c5-454f-94c9-a865034144a5', 'b9109ece-d390-4673-9d08-857d184c2aab', '人力行政中心', '行政组', b'1', 'Normal', '500000', '人力行政中心-行政组');
INSERT INTO `organizationexpansions` VALUES ('34b90a34-a8c2-44e7-be2f-5fa056414491', 'a6590cbf-a252-4532-aa16-012a96f170cc', '啊啊啊', '啊啊', b'1', 'Normal', '700000', '啊啊啊-啊啊');
INSERT INTO `organizationexpansions` VALUES ('384c66df-b97e-430c-bdd4-8e9cd84d8ef7', '3d41347c-2262-40f9-821a-e7bc9bebb177', '交通', 'asdadsad', b'1', 'Normal', '500000', '默认顶级-交通-');
INSERT INTO `organizationexpansions` VALUES ('384c66df-b97e-430c-bdd4-8e9cd84d8ef7', '43585f44-9b39-4f88-ace6-ccda02ae7200', '交通', '后勤', b'1', 'Normal', '500000', '交通-后勤');
INSERT INTO `organizationexpansions` VALUES ('3b58adf3-bb61-4215-9ca7-453e09365082', '3d3d331b-c481-4cd0-b796-aebe49ecc8b9', '重庆分公司', '财务部', b'1', 'Filiale', '500000', '重庆分公司-财务部');
INSERT INTO `organizationexpansions` VALUES ('3b58adf3-bb61-4215-9ca7-453e09365082', '56d8f9a1-f4b7-46de-9a21-31df94936a18', '重庆分公司', '南区', b'0', 'Filiale', '500000', '重庆分公司-事业部-南区');
INSERT INTO `organizationexpansions` VALUES ('3b58adf3-bb61-4215-9ca7-453e09365082', '608374ba-ed02-4d2a-904f-062918233d3d', '重庆分公司', '西区', b'0', 'Filiale', '500000', '重庆分公司-事业部-西区');
INSERT INTO `organizationexpansions` VALUES ('3b58adf3-bb61-4215-9ca7-453e09365082', '663974d3-ee55-4e36-84c0-8da5da98deb9', '重庆分公司', '北区', b'0', 'Filiale', '500000', '重庆分公司-事业部-北区');
INSERT INTO `organizationexpansions` VALUES ('3b58adf3-bb61-4215-9ca7-453e09365082', '846fe421-dfb7-491c-b4a8-940b1257f27c', '重庆分公司', '拓展部', b'1', 'Filiale', '500000', '重庆分公司-拓展部');
INSERT INTO `organizationexpansions` VALUES ('3b58adf3-bb61-4215-9ca7-453e09365082', 'ceacb8f6-b713-457d-bce5-bb40360f190a', '重庆分公司', '事业部', b'1', 'Filiale', '500000', '重庆分公司-事业部');
INSERT INTO `organizationexpansions` VALUES ('3b58adf3-bb61-4215-9ca7-453e09365082', 'd3825c1b-4060-4a17-a920-c94055548784', '重庆分公司', '人力行政部', b'1', 'Filiale', '500000', '重庆分公司-人力行政部');
INSERT INTO `organizationexpansions` VALUES ('3b58adf3-bb61-4215-9ca7-453e09365082', 'f34a6dfd-4938-4c18-bc83-ee1166a95161', '重庆分公司', '策划部', b'1', 'Filiale', '500000', '重庆分公司-策划部');
INSERT INTO `organizationexpansions` VALUES ('3b58adf3-bb61-4215-9ca7-453e09365082', 'f5db9c5b-d065-4611-9337-09b7f356d048', '重庆分公司', '招商运营部', b'1', 'Filiale', '500000', '重庆分公司-招商运营部');
INSERT INTO `organizationexpansions` VALUES ('6a50c88e-a53f-46df-9314-469b5de5a555', '70d7304d-7b79-4e30-b400-1a9bdc65d123', '数据运营中心', '对外合作部', b'1', 'Normal', NULL, '数据运营中心-对外合作部');
INSERT INTO `organizationexpansions` VALUES ('6a50c88e-a53f-46df-9314-469b5de5a555', '871fd1ac-bfb6-4dd1-b8fd-f78b4e9ffecb', '数据运营中心', '数据分析部', b'1', 'Normal', NULL, '数据运营中心-数据分析部');
INSERT INTO `organizationexpansions` VALUES ('6a50c88e-a53f-46df-9314-469b5de5a555', 'e590fbd0-ca40-479c-8f01-7a0d4c13940b', '数据运营中心', '客服部', b'1', 'Normal', NULL, '数据运营中心-客服部');
INSERT INTO `organizationexpansions` VALUES ('6a50c88e-a53f-46df-9314-469b5de5a555', 'e771e1a9-e47a-4805-a10c-09e2c2b16aed', '数据运营中心', '运营部', b'1', 'Normal', NULL, '数据运营中心-运营部');
INSERT INTO `organizationexpansions` VALUES ('6cc1f3fc-245b-4f24-8eb2-2f0115152f5f', '85751dab-3e9b-4c16-a09d-0427c3d11983', '财务中心', '会计与税务组', b'1', 'Normal', NULL, '财务中心-会计与税务组');
INSERT INTO `organizationexpansions` VALUES ('6cc1f3fc-245b-4f24-8eb2-2f0115152f5f', 'd1f58a08-e9b2-4f6a-9241-2c48f6dab414', '财务中心', '资金结算组', b'1', 'Normal', NULL, '财务中心-资金结算组');
INSERT INTO `organizationexpansions` VALUES ('6cc1f3fc-245b-4f24-8eb2-2f0115152f5f', 'eabb8bea-0b32-409c-bfad-cd47e44a3b54', '财务中心', '财务管理与内控组', b'1', 'Normal', NULL, '财务中心-财务管理与内控组');
INSERT INTO `organizationexpansions` VALUES ('70a943af-fd33-48a4-8e87-0aafbeb5dce1', '30a98f89-0a85-4fc1-87ea-c27638d1b5e8', '风控中心', '新空间', b'1', 'Normal', NULL, '风控中心-新空间');
INSERT INTO `organizationexpansions` VALUES ('70a943af-fd33-48a4-8e87-0aafbeb5dce1', '54ddd090-5e69-447f-8b34-cd0880bb5095', '风控中心', '建部门', b'1', 'Normal', NULL, '风控中心-建部门');
INSERT INTO `organizationexpansions` VALUES ('70a943af-fd33-48a4-8e87-0aafbeb5dce1', '6b60d3b4-690b-4e6f-bea7-eb1f101913b1', '风控中心', '审计组', b'1', 'Normal', NULL, '风控中心-审计组');
INSERT INTO `organizationexpansions` VALUES ('70a943af-fd33-48a4-8e87-0aafbeb5dce1', '6bc64ed3-ccf8-49f5-83d6-aa45392febb9', '风控中心', '金控组', b'1', 'Normal', NULL, '风控中心-金控组');
INSERT INTO `organizationexpansions` VALUES ('70a943af-fd33-48a4-8e87-0aafbeb5dce1', '96d01ba2-79fd-493c-b0af-abc907d41c06', '风控中心', '法务组', b'1', 'Normal', NULL, '风控中心-法务组');
INSERT INTO `organizationexpansions` VALUES ('80a09984-6714-442c-8927-b75dc3202e62', 'a02b751f-c6d5-4649-88b1-d967f9829717', '南区', '北区', b'1', 'Normal', NULL, '南区-北区');
INSERT INTO `organizationexpansions` VALUES ('8777f829-ea1e-48ee-9685-a68b0f98583e', '5d365311-187f-43dc-a727-c03eee845878', '成都分公司', '拓展部', b'1', 'Normal', '600000', '成都分公司-拓展部');
INSERT INTO `organizationexpansions` VALUES ('8777f829-ea1e-48ee-9685-a68b0f98583e', '80a09984-6714-442c-8927-b75dc3202e62', '成都分公司', '南区', b'0', 'Normal', '600000', '成都分公司-事业部-南区');
INSERT INTO `organizationexpansions` VALUES ('8777f829-ea1e-48ee-9685-a68b0f98583e', 'a02b751f-c6d5-4649-88b1-d967f9829717', '成都分公司', '北区', b'0', 'Normal', '600000', '成都分公司-事业部-南区-北区');
INSERT INTO `organizationexpansions` VALUES ('8777f829-ea1e-48ee-9685-a68b0f98583e', 'a9b856e3-5925-4198-8e24-5606455d02ac', '成都分公司', '财务部', b'1', 'Normal', '600000', '成都分公司-财务部');
INSERT INTO `organizationexpansions` VALUES ('8777f829-ea1e-48ee-9685-a68b0f98583e', 'ca7d6f90-4d37-4f7e-bf08-c5a4338a1f91', '成都分公司', '事业部', b'1', 'Normal', '600000', '成都分公司-事业部');
INSERT INTO `organizationexpansions` VALUES ('acb19cf0-0897-4d1c-9079-34a60d06407e', '3b58adf3-bb61-4215-9ca7-453e09365082', '营销运营中心', '重庆分公司', b'1', 'Normal', '500000', '营销运营中心-重庆分公司');
INSERT INTO `organizationexpansions` VALUES ('acb19cf0-0897-4d1c-9079-34a60d06407e', '3d3d331b-c481-4cd0-b796-aebe49ecc8b9', '营销运营中心', '财务部', b'0', 'Normal', '500000', '营销运营中心-重庆分公司-财务部');
INSERT INTO `organizationexpansions` VALUES ('acb19cf0-0897-4d1c-9079-34a60d06407e', '56d8f9a1-f4b7-46de-9a21-31df94936a18', '营销运营中心', '南区', b'0', 'Normal', '500000', '营销运营中心-重庆分公司-事业部-南区');
INSERT INTO `organizationexpansions` VALUES ('acb19cf0-0897-4d1c-9079-34a60d06407e', '5d365311-187f-43dc-a727-c03eee845878', '营销运营中心', '拓展部', b'0', 'Normal', '500000', '营销运营中心-成都分公司-拓展部');
INSERT INTO `organizationexpansions` VALUES ('acb19cf0-0897-4d1c-9079-34a60d06407e', '608374ba-ed02-4d2a-904f-062918233d3d', '营销运营中心', '西区', b'0', 'Normal', '500000', '营销运营中心-重庆分公司-事业部-西区');
INSERT INTO `organizationexpansions` VALUES ('acb19cf0-0897-4d1c-9079-34a60d06407e', '663974d3-ee55-4e36-84c0-8da5da98deb9', '营销运营中心', '北区', b'0', 'Normal', '500000', '营销运营中心-重庆分公司-事业部-北区');
INSERT INTO `organizationexpansions` VALUES ('acb19cf0-0897-4d1c-9079-34a60d06407e', '80a09984-6714-442c-8927-b75dc3202e62', '营销运营中心', '南区', b'0', 'Normal', '500000', '营销运营中心-成都分公司-事业部-南区');
INSERT INTO `organizationexpansions` VALUES ('acb19cf0-0897-4d1c-9079-34a60d06407e', '846fe421-dfb7-491c-b4a8-940b1257f27c', '营销运营中心', '拓展部', b'0', 'Normal', '500000', '营销运营中心-重庆分公司-拓展部');
INSERT INTO `organizationexpansions` VALUES ('acb19cf0-0897-4d1c-9079-34a60d06407e', '8777f829-ea1e-48ee-9685-a68b0f98583e', '营销运营中心', '成都分公司', b'1', 'Normal', '500000', '营销运营中心-成都分公司');
INSERT INTO `organizationexpansions` VALUES ('acb19cf0-0897-4d1c-9079-34a60d06407e', 'a02b751f-c6d5-4649-88b1-d967f9829717', '营销运营中心', '北区', b'0', 'Normal', '500000', '营销运营中心-成都分公司-事业部-南区-北区');
INSERT INTO `organizationexpansions` VALUES ('acb19cf0-0897-4d1c-9079-34a60d06407e', 'a9b856e3-5925-4198-8e24-5606455d02ac', '营销运营中心', '财务部', b'0', 'Normal', '500000', '营销运营中心-成都分公司-财务部');
INSERT INTO `organizationexpansions` VALUES ('acb19cf0-0897-4d1c-9079-34a60d06407e', 'ca7d6f90-4d37-4f7e-bf08-c5a4338a1f91', '营销运营中心', '事业部', b'0', 'Normal', '500000', '营销运营中心-成都分公司-事业部');
INSERT INTO `organizationexpansions` VALUES ('acb19cf0-0897-4d1c-9079-34a60d06407e', 'ceacb8f6-b713-457d-bce5-bb40360f190a', '营销运营中心', '事业部', b'0', 'Normal', '500000', '营销运营中心-重庆分公司-事业部');
INSERT INTO `organizationexpansions` VALUES ('acb19cf0-0897-4d1c-9079-34a60d06407e', 'd3825c1b-4060-4a17-a920-c94055548784', '营销运营中心', '人力行政部', b'0', 'Normal', '500000', '营销运营中心-重庆分公司-人力行政部');
INSERT INTO `organizationexpansions` VALUES ('acb19cf0-0897-4d1c-9079-34a60d06407e', 'f34a6dfd-4938-4c18-bc83-ee1166a95161', '营销运营中心', '策划部', b'0', 'Normal', '500000', '营销运营中心-重庆分公司-策划部');
INSERT INTO `organizationexpansions` VALUES ('acb19cf0-0897-4d1c-9079-34a60d06407e', 'f5db9c5b-d065-4611-9337-09b7f356d048', '营销运营中心', '招商运营部', b'0', 'Normal', '500000', '营销运营中心-重庆分公司-招商运营部');
INSERT INTO `organizationexpansions` VALUES ('b9109ece-d390-4673-9d08-857d184c2aab', 'b03129f0-fc88-4cee-ba5a-cb626a8f89f2', '行政组', 'IT技术支持', b'1', 'Normal', NULL, '默认顶级-行政组-');
INSERT INTO `organizationexpansions` VALUES ('bda28aeb-8403-4a6d-af3e-5a1b88bfdbb1', '00326161-60c3-4db9-9283-fce99fa5ecd9', '交通部', 'q111', b'1', 'Normal', '500000', '交通部-q111');
INSERT INTO `organizationexpansions` VALUES ('bda28aeb-8403-4a6d-af3e-5a1b88bfdbb1', '34b90a34-a8c2-44e7-be2f-5fa056414491', '交通部', '啊啊啊', b'1', 'Normal', '500000', '交通部-啊啊啊');
INSERT INTO `organizationexpansions` VALUES ('bda28aeb-8403-4a6d-af3e-5a1b88bfdbb1', '384c66df-b97e-430c-bdd4-8e9cd84d8ef7', '交通部', '交通', b'1', 'Normal', '500000', '交通部-交通');
INSERT INTO `organizationexpansions` VALUES ('bda28aeb-8403-4a6d-af3e-5a1b88bfdbb1', '3d41347c-2262-40f9-821a-e7bc9bebb177', '交通部', 'asdadsad', b'0', 'Normal', '500000', '默认顶级-交通部-交通-');
INSERT INTO `organizationexpansions` VALUES ('bda28aeb-8403-4a6d-af3e-5a1b88bfdbb1', '43585f44-9b39-4f88-ace6-ccda02ae7200', '交通部', '后勤', b'0', 'Normal', '500000', '交通部-交通-后勤');
INSERT INTO `organizationexpansions` VALUES ('bda28aeb-8403-4a6d-af3e-5a1b88bfdbb1', 'a6590cbf-a252-4532-aa16-012a96f170cc', '交通部', '啊啊', b'0', 'Normal', '500000', '交通部-啊啊啊-啊啊');
INSERT INTO `organizationexpansions` VALUES ('bda28aeb-8403-4a6d-af3e-5a1b88bfdbb1', 'c104b5d3-65df-4f64-a310-7b46d5b57b3f', '交通部', '嗷嗷嗷', b'1', 'Normal', '500000', '交通部-嗷嗷嗷');
INSERT INTO `organizationexpansions` VALUES ('bda28aeb-8403-4a6d-af3e-5a1b88bfdbb1', 'f75e1275-b27a-454a-9e9e-987fdf738e0e', '交通部', '地方烦烦烦烦烦烦烦烦烦烦烦烦', b'1', 'Normal', '500000', '交通部-wwww');
INSERT INTO `organizationexpansions` VALUES ('be042d04-9519-45e9-bb40-24049ea7c967', 'ce5e5b5d-076a-451d-a3ea-503ce1b2f5b9', '基础服务部', '工具研发组', b'1', 'Normal', NULL, '基础服务部-工具研发组');
INSERT INTO `organizationexpansions` VALUES ('be042d04-9519-45e9-bb40-24049ea7c967', 'e891ee7f-348d-4de0-a53a-2ba09d4261c5', '基础服务部', '测试运维组', b'1', 'Normal', NULL, '基础服务部-测试运维组');
INSERT INTO `organizationexpansions` VALUES ('be042d04-9519-45e9-bb40-24049ea7c967', 'ef4db299-404f-41be-8617-54f2cfe29231', '基础服务部', '大数据组', b'1', 'Normal', NULL, '基础服务部-大数据组');
INSERT INTO `organizationexpansions` VALUES ('be042d04-9519-45e9-bb40-24049ea7c967', 'ff37c09e-622f-4d6b-8a5e-db734d3da562', '基础服务部', '系统架构师', b'1', 'Normal', NULL, '基础服务部-系统架构师');
INSERT INTO `organizationexpansions` VALUES ('bf2ceeff-fd7e-472d-94c2-9404f88dced0', 'febab76a-8a44-4eff-851c-470263f6b697', '后台部', '656565', b'1', 'Normal', '500000', '默认顶级-后台部-');
INSERT INTO `organizationexpansions` VALUES ('ca7d6f90-4d37-4f7e-bf08-c5a4338a1f91', '80a09984-6714-442c-8927-b75dc3202e62', '事业部', '南区', b'1', 'Normal', NULL, '事业部-南区');
INSERT INTO `organizationexpansions` VALUES ('ca7d6f90-4d37-4f7e-bf08-c5a4338a1f91', 'a02b751f-c6d5-4649-88b1-d967f9829717', '事业部', '北区', b'0', 'Normal', NULL, '事业部-南区-北区');
INSERT INTO `organizationexpansions` VALUES ('cd5677ae-0841-4027-89c0-4654a853a8ec', '2101cfe4-60c7-472d-99c5-65a041705eb4', '测试部门', '111', b'1', 'Normal', '500000', '默认顶级-测试部门-');
INSERT INTO `organizationexpansions` VALUES ('ceacb8f6-b713-457d-bce5-bb40360f190a', '56d8f9a1-f4b7-46de-9a21-31df94936a18', '事业部', '南区', b'1', 'Normal', NULL, '事业部-南区');
INSERT INTO `organizationexpansions` VALUES ('ceacb8f6-b713-457d-bce5-bb40360f190a', '608374ba-ed02-4d2a-904f-062918233d3d', '事业部', '西区', b'1', 'Normal', NULL, '事业部-西区');
INSERT INTO `organizationexpansions` VALUES ('ceacb8f6-b713-457d-bce5-bb40360f190a', '663974d3-ee55-4e36-84c0-8da5da98deb9', '事业部', '北区', b'1', 'Normal', NULL, '事业部-北区');
INSERT INTO `organizationexpansions` VALUES ('cedcf386-fe6a-4f27-a11c-cef0b19c3956', '46b3e5a9-da45-438b-8e32-a9a935098a1e', '产品设计部', '产品组', b'1', 'Normal', NULL, '产品设计部-产品组');
INSERT INTO `organizationexpansions` VALUES ('cedcf386-fe6a-4f27-a11c-cef0b19c3956', '56834ed4-5f38-481f-b1b2-232aed76fed3', '产品设计部', 'UI组', b'1', 'Normal', NULL, '产品设计部-UI组');
INSERT INTO `organizationexpansions` VALUES ('de4b5e21-61e1-4854-8a18-5e89bd070bd1', '507be2c5-171a-4b36-9b95-02560330258d', '技术研发中心', '质量保障部', b'1', 'Normal', NULL, '技术研发中心-质量保障部');
INSERT INTO `organizationexpansions` VALUES ('de4b5e21-61e1-4854-8a18-5e89bd070bd1', 'b62f025a-eeaa-4bb9-9ecf-e8068e84f7de', '技术研发中心', '后端组', b'0', 'Normal', NULL, '技术研发中心-应用研发部-后端组');
INSERT INTO `organizationexpansions` VALUES ('de4b5e21-61e1-4854-8a18-5e89bd070bd1', 'be042d04-9519-45e9-bb40-24049ea7c967', '技术研发中心', '基础服务部', b'1', 'Normal', NULL, '技术研发中心-基础服务部');
INSERT INTO `organizationexpansions` VALUES ('de4b5e21-61e1-4854-8a18-5e89bd070bd1', 'cb12edc3-7489-471d-b976-73bbfd1b6277', '技术研发中心', 'Web组', b'0', 'Normal', NULL, '技术研发中心-应用研发部-Web组');
INSERT INTO `organizationexpansions` VALUES ('de4b5e21-61e1-4854-8a18-5e89bd070bd1', 'ce5e5b5d-076a-451d-a3ea-503ce1b2f5b9', '技术研发中心', '工具研发组', b'0', 'Normal', NULL, '技术研发中心-基础服务部-工具研发组');
INSERT INTO `organizationexpansions` VALUES ('de4b5e21-61e1-4854-8a18-5e89bd070bd1', 'e5768524-dc68-4a47-bf2a-68834258a375', '技术研发中心', '应用研发部', b'1', 'Normal', NULL, '技术研发中心-应用研发部');
INSERT INTO `organizationexpansions` VALUES ('de4b5e21-61e1-4854-8a18-5e89bd070bd1', 'e891ee7f-348d-4de0-a53a-2ba09d4261c5', '技术研发中心', '测试运维组', b'0', 'Normal', NULL, '技术研发中心-基础服务部-测试运维组');
INSERT INTO `organizationexpansions` VALUES ('de4b5e21-61e1-4854-8a18-5e89bd070bd1', 'ef4db299-404f-41be-8617-54f2cfe29231', '技术研发中心', '大数据组', b'0', 'Normal', NULL, '技术研发中心-基础服务部-大数据组');
INSERT INTO `organizationexpansions` VALUES ('de4b5e21-61e1-4854-8a18-5e89bd070bd1', 'f06cf42b-d5ca-4eca-b3d2-1f5edbd7110d', '技术研发中心', '移动组', b'0', 'Normal', NULL, '技术研发中心-应用研发部-移动组');
INSERT INTO `organizationexpansions` VALUES ('de4b5e21-61e1-4854-8a18-5e89bd070bd1', 'ff37c09e-622f-4d6b-8a5e-db734d3da562', '技术研发中心', '系统架构师', b'0', 'Normal', NULL, '技术研发中心-基础服务部-系统架构师');
INSERT INTO `organizationexpansions` VALUES ('e5768524-dc68-4a47-bf2a-68834258a375', 'b62f025a-eeaa-4bb9-9ecf-e8068e84f7de', '应用研发部', '后端组', b'1', 'Normal', NULL, '应用研发部-后端组');
INSERT INTO `organizationexpansions` VALUES ('e5768524-dc68-4a47-bf2a-68834258a375', 'cb12edc3-7489-471d-b976-73bbfd1b6277', '应用研发部', 'Web组', b'1', 'Normal', NULL, '应用研发部-Web组');
INSERT INTO `organizationexpansions` VALUES ('e5768524-dc68-4a47-bf2a-68834258a375', 'f06cf42b-d5ca-4eca-b3d2-1f5edbd7110d', '应用研发部', '移动组', b'1', 'Normal', NULL, '应用研发部-移动组');

-- ----------------------------
-- Table structure for organizations
-- ----------------------------
DROP TABLE IF EXISTS `organizations`;
CREATE TABLE `organizations`  (
  `Id` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '主键',
  `Address` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Assistant` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Fax` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `IsDeleted` bit(1) NOT NULL,
  `LeaderManager` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Manager` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `OrganizationName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `ParentId` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT '0',
  `Phone` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Sort` int(11) NULL DEFAULT NULL,
  `Superiors` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Type` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `City` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `PoolDay` int(255) NULL DEFAULT 0,
  `DeleteTime` datetime(0) NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP(0),
  `DeleteUser` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP(0),
  `CreateUser` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `MeritPayRatioRule` varchar(127) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of organizations
-- ----------------------------
INSERT INTO `organizations` VALUES ('1', NULL, '', NULL, b'0', '..', 'admin', '总部', '0', '..', 0, NULL, 'Bloc', '500000', 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('30a98f89-0a85-4fc1-87ea-c27638d1b5e8', '数据谷', NULL, NULL, b'0', '大王', NULL, '新空间', '70a943af-fd33-48a4-8e87-0aafbeb5dce1', '88888888', 0, NULL, 'Normal', '500000', 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('33b48f69-96c5-454f-94c9-a865034144a5', '000000', NULL, '0000', b'0', '人力主管', NULL, '人力行政中心', '1', '00000', 0, NULL, 'Normal', '500000', 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('384c66df-b97e-430c-bdd4-8e9cd84d8ef7', '渝北区', NULL, '8888888', b'0', '司令', NULL, '交通', 'bda28aeb-8403-4a6d-af3e-5a1b88bfdbb1', '88888888', 0, NULL, 'Normal', '500000', 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('3b58adf3-bb61-4215-9ca7-453e09365082', NULL, NULL, NULL, b'0', NULL, NULL, '重庆分公司', 'acb19cf0-0897-4d1c-9079-34a60d06407e', NULL, 0, NULL, 'Filiale', '500000', 0, '2018-10-31 00:08:07', NULL, '2018-10-31 00:08:07', NULL, NULL);
INSERT INTO `organizations` VALUES ('3d3d331b-c481-4cd0-b796-aebe49ecc8b9', NULL, NULL, NULL, b'0', NULL, NULL, '财务部', '3b58adf3-bb61-4215-9ca7-453e09365082', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('46b3e5a9-da45-438b-8e32-a9a935098a1e', NULL, NULL, NULL, b'0', NULL, NULL, '产品组', 'cedcf386-fe6a-4f27-a11c-cef0b19c3956', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('4cba486f-a98e-4d95-8746-551304bbae03', NULL, NULL, NULL, b'0', NULL, NULL, '最顶部', '0', '13167874692', NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('507be2c5-171a-4b36-9b95-02560330258d', NULL, NULL, NULL, b'0', NULL, NULL, '质量保障部', 'de4b5e21-61e1-4854-8a18-5e89bd070bd1', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('54ddd090-5e69-447f-8b34-cd0880bb5095', NULL, NULL, NULL, b'0', NULL, NULL, '建部门', '70a943af-fd33-48a4-8e87-0aafbeb5dce1', NULL, 0, NULL, 'Normal', '600000', 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('56834ed4-5f38-481f-b1b2-232aed76fed3', NULL, NULL, NULL, b'0', NULL, NULL, 'UI组', 'cedcf386-fe6a-4f27-a11c-cef0b19c3956', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('56d8f9a1-f4b7-46de-9a21-31df94936a18', NULL, NULL, NULL, b'0', NULL, NULL, '南区', 'ceacb8f6-b713-457d-bce5-bb40360f190a', NULL, 0, NULL, 'Region', '500000', 0, '2018-10-30 22:55:40', NULL, '2018-10-30 22:55:40', NULL, NULL);
INSERT INTO `organizations` VALUES ('597282c8-6714-4333-aca6-f12c4c8ba3a5', NULL, NULL, NULL, b'0', NULL, NULL, '总裁室', '1', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('5c685404-e11a-4285-9c04-c02aec48d658', NULL, NULL, NULL, b'0', NULL, NULL, '45', 'd6d9ae8e-2f74-4053-9888-affafd11dffb', '15104545454', NULL, NULL, NULL, NULL, 0, NULL, NULL, '2018-12-25 16:16:28', NULL, NULL);
INSERT INTO `organizations` VALUES ('5d365311-187f-43dc-a727-c03eee845878', NULL, NULL, NULL, b'0', NULL, NULL, '拓展部', '8777f829-ea1e-48ee-9685-a68b0f98583e', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('608374ba-ed02-4d2a-904f-062918233d3d', NULL, NULL, NULL, b'0', NULL, NULL, '西区', 'ceacb8f6-b713-457d-bce5-bb40360f190a', NULL, 0, NULL, 'Region', NULL, 0, '2018-10-30 22:55:41', NULL, '2018-10-30 22:55:41', NULL, NULL);
INSERT INTO `organizations` VALUES ('663974d3-ee55-4e36-84c0-8da5da98deb9', NULL, NULL, NULL, b'0', NULL, NULL, '北区', 'ceacb8f6-b713-457d-bce5-bb40360f190a', NULL, 0, NULL, 'Region', NULL, 0, '2018-10-30 22:55:43', NULL, '2018-10-30 22:55:43', NULL, NULL);
INSERT INTO `organizations` VALUES ('6a50c88e-a53f-46df-9314-469b5de5a555', NULL, NULL, NULL, b'0', NULL, NULL, '数据运营中心', '1', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('6b60d3b4-690b-4e6f-bea7-eb1f101913b1', NULL, NULL, NULL, b'0', NULL, NULL, '审计组', '70a943af-fd33-48a4-8e87-0aafbeb5dce1', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('6bc64ed3-ccf8-49f5-83d6-aa45392febb9', NULL, NULL, NULL, b'0', NULL, NULL, '金控组', '70a943af-fd33-48a4-8e87-0aafbeb5dce1', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('6cc1f3fc-245b-4f24-8eb2-2f0115152f5f', NULL, NULL, NULL, b'0', NULL, NULL, '财务中心', '1', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('70a943af-fd33-48a4-8e87-0aafbeb5dce1', NULL, NULL, NULL, b'0', NULL, NULL, '风控中心', '1', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('70d7304d-7b79-4e30-b400-1a9bdc65d123', NULL, NULL, NULL, b'0', NULL, NULL, '对外合作部', '6a50c88e-a53f-46df-9314-469b5de5a555', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('80a09984-6714-442c-8927-b75dc3202e62', NULL, NULL, NULL, b'0', NULL, NULL, '南区', 'ca7d6f90-4d37-4f7e-bf08-c5a4338a1f91', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('846fe421-dfb7-491c-b4a8-940b1257f27c', NULL, NULL, NULL, b'0', NULL, NULL, '拓展部', '3b58adf3-bb61-4215-9ca7-453e09365082', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('85751dab-3e9b-4c16-a09d-0427c3d11983', NULL, NULL, NULL, b'0', NULL, NULL, '会计与税务组', '6cc1f3fc-245b-4f24-8eb2-2f0115152f5f', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('8644fb1b-7ae8-4c7d-85fa-93f9ea53c5fb', NULL, NULL, NULL, b'0', NULL, NULL, '10101', '5c685404-e11a-4285-9c04-c02aec48d658', '13213133133', NULL, NULL, NULL, NULL, 0, NULL, NULL, '2018-12-25 16:21:17', NULL, NULL);
INSERT INTO `organizations` VALUES ('866d150f-ba37-4c99-b608-5bd95b9a7fc6', NULL, NULL, NULL, b'0', NULL, NULL, '一级', '0', '18162585465', NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('871fd1ac-bfb6-4dd1-b8fd-f78b4e9ffecb', NULL, NULL, NULL, b'0', NULL, NULL, '数据分析部', '6a50c88e-a53f-46df-9314-469b5de5a555', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('8777f829-ea1e-48ee-9685-a68b0f98583e', NULL, NULL, NULL, b'0', NULL, NULL, '成都分公司', 'acb19cf0-0897-4d1c-9079-34a60d06407e', NULL, 0, NULL, 'Normal', '600000', 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('8ac1b28b-3fbd-4907-b44d-89d4bebd46ee', NULL, NULL, NULL, b'0', NULL, NULL, '人力资源组', '33b48f69-96c5-454f-94c9-a865034144a5', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('96d01ba2-79fd-493c-b0af-abc907d41c06', NULL, NULL, NULL, b'0', NULL, NULL, '法务组', '70a943af-fd33-48a4-8e87-0aafbeb5dce1', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('9dce0dca-3876-46f8-8d12-6a6eca4fe50b', '渝北区', NULL, '13226129567', b'0', '工商', NULL, '工商管理部', '1', '13826129567', 0, NULL, 'Bloc', '500000', 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('a02b751f-c6d5-4649-88b1-d967f9829717', NULL, NULL, NULL, b'0', NULL, NULL, '北区', '80a09984-6714-442c-8927-b75dc3202e62', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('a2c2d613-38a1-4a48-a762-914884a783ad', NULL, NULL, NULL, b'0', NULL, NULL, '核桃仁', '73653e40-0a1e-477a-9f54-73b6f0bf5393', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('a9b856e3-5925-4198-8e24-5606455d02ac', NULL, NULL, NULL, b'0', NULL, NULL, '财务部', '8777f829-ea1e-48ee-9685-a68b0f98583e', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('acb19cf0-0897-4d1c-9079-34a60d06407e', NULL, NULL, NULL, b'0', NULL, NULL, '营销运营中心', '1', NULL, 0, NULL, 'Normal', '500000', 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('af0689f6-3ab4-48ed-b9f5-3562557be7d0', NULL, NULL, NULL, b'0', NULL, NULL, '二级部门', '	4cba486f-a98e-4d95-8746-551304bbae03', '13167874692', NULL, NULL, NULL, NULL, 0, NULL, NULL, '2018-12-25 16:13:09', NULL, NULL);
INSERT INTO `organizations` VALUES ('b03129f0-fc88-4cee-ba5a-cb626a8f89f2', NULL, NULL, NULL, b'0', NULL, NULL, 'IT技术支持', 'b9109ece-d390-4673-9d08-857d184c2aab', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('b2c2373e-1b05-47f4-b3e0-f0bf0ba2c5f4', NULL, NULL, NULL, b'0', NULL, NULL, '0', '	4cba486f-a98e-4d95-8746-551304bbae03', '13167874692', NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('b62f025a-eeaa-4bb9-9ecf-e8068e84f7de', NULL, NULL, NULL, b'0', NULL, NULL, '后端组', 'e5768524-dc68-4a47-bf2a-68834258a375', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('b9109ece-d390-4673-9d08-857d184c2aab', NULL, NULL, NULL, b'0', NULL, NULL, '行政组', '33b48f69-96c5-454f-94c9-a865034144a5', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('bda28aeb-8403-4a6d-af3e-5a1b88bfdbb1', '渝北区', NULL, '88888888', b'0', '习大大', NULL, '交通部', '0', '88888888', 0, NULL, 'Normal', '500000', 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('be042d04-9519-45e9-bb40-24049ea7c967', NULL, NULL, NULL, b'0', NULL, NULL, '基础服务部', 'de4b5e21-61e1-4854-8a18-5e89bd070bd1', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('ca7d6f90-4d37-4f7e-bf08-c5a4338a1f91', NULL, NULL, NULL, b'0', NULL, NULL, '事业部', '8777f829-ea1e-48ee-9685-a68b0f98583e', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('cb12edc3-7489-471d-b976-73bbfd1b6277', NULL, NULL, NULL, b'0', NULL, NULL, 'Web组', 'e5768524-dc68-4a47-bf2a-68834258a375', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('ce5e5b5d-076a-451d-a3ea-503ce1b2f5b9', NULL, NULL, NULL, b'0', NULL, NULL, '工具研发组', 'be042d04-9519-45e9-bb40-24049ea7c967', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('ceacb8f6-b713-457d-bce5-bb40360f190a', NULL, NULL, NULL, b'0', NULL, NULL, '事业部', '3b58adf3-bb61-4215-9ca7-453e09365082', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('cedcf386-fe6a-4f27-a11c-cef0b19c3956', NULL, NULL, NULL, b'0', NULL, NULL, '产品设计部', '1', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('d132fcd8-5d44-46f1-a1d6-deee3983218c', NULL, NULL, NULL, b'0', NULL, NULL, '二', '0', '13167874692', NULL, NULL, NULL, NULL, 0, NULL, NULL, '2018-12-25 16:15:36', NULL, NULL);
INSERT INTO `organizations` VALUES ('d1f58a08-e9b2-4f6a-9241-2c48f6dab414', NULL, NULL, NULL, b'0', NULL, NULL, '资金结算组', '6cc1f3fc-245b-4f24-8eb2-2f0115152f5f', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('d3825c1b-4060-4a17-a920-c94055548784', NULL, NULL, NULL, b'0', NULL, NULL, '人力行政部', '3b58adf3-bb61-4215-9ca7-453e09365082', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('d6d9ae8e-2f74-4053-9888-affafd11dffb', NULL, NULL, NULL, b'0', NULL, NULL, '测试', '0', '13167874692', NULL, NULL, NULL, NULL, 0, NULL, NULL, '2018-12-25 16:15:19', NULL, NULL);
INSERT INTO `organizations` VALUES ('de4b5e21-61e1-4854-8a18-5e89bd070bd1', NULL, NULL, NULL, b'0', NULL, NULL, '技术研发中心', '1', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('e5768524-dc68-4a47-bf2a-68834258a375', NULL, NULL, NULL, b'0', NULL, NULL, '应用研发部', 'de4b5e21-61e1-4854-8a18-5e89bd070bd1', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('e590fbd0-ca40-479c-8f01-7a0d4c13940b', NULL, NULL, NULL, b'0', NULL, NULL, '客服部', '6a50c88e-a53f-46df-9314-469b5de5a555', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('e771e1a9-e47a-4805-a10c-09e2c2b16aed', NULL, NULL, NULL, b'0', NULL, NULL, '运营部', '6a50c88e-a53f-46df-9314-469b5de5a555', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('e891ee7f-348d-4de0-a53a-2ba09d4261c5', NULL, NULL, NULL, b'0', NULL, NULL, '测试运维组', 'be042d04-9519-45e9-bb40-24049ea7c967', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('eabb8bea-0b32-409c-bfad-cd47e44a3b54', NULL, NULL, NULL, b'0', NULL, NULL, '财务管理与内控组', '6cc1f3fc-245b-4f24-8eb2-2f0115152f5f', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('ef4db299-404f-41be-8617-54f2cfe29231', NULL, NULL, NULL, b'0', NULL, NULL, '大数据组', 'be042d04-9519-45e9-bb40-24049ea7c967', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('f06cf42b-d5ca-4eca-b3d2-1f5edbd7110d', NULL, NULL, NULL, b'0', NULL, NULL, '移动组', 'e5768524-dc68-4a47-bf2a-68834258a375', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('f34a6dfd-4938-4c18-bc83-ee1166a95161', NULL, NULL, NULL, b'0', NULL, NULL, '策划部', '3b58adf3-bb61-4215-9ca7-453e09365082', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('f5db9c5b-d065-4611-9337-09b7f356d048', NULL, NULL, NULL, b'0', NULL, NULL, '招商运营部', '3b58adf3-bb61-4215-9ca7-453e09365082', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `organizations` VALUES ('ff37c09e-622f-4d6b-8a5e-db734d3da562', NULL, NULL, NULL, b'0', NULL, NULL, '系统架构师', 'be042d04-9519-45e9-bb40-24049ea7c967', NULL, 0, NULL, 'Normal', NULL, 0, NULL, NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for permissionitems
-- ----------------------------
DROP TABLE IF EXISTS `permissionitems`;
CREATE TABLE `permissionitems`  (
  `Id` varchar(127) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ApplicationId` varchar(127) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `Groups` varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `IsDeleted` bit(1) NOT NULL,
  `Name` varchar(127) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Records of permissionitems
-- ----------------------------
INSERT INTO `permissionitems` VALUES ('Delete', NULL, '数据维护', b'0', '删除');
INSERT INTO `permissionitems` VALUES ('Endit', NULL, '数据维护', b'0', '编辑');
INSERT INTO `permissionitems` VALUES ('Query', NULL, '数据浏览', b'0', '查看');

-- ----------------------------
-- Table structure for rolepermissions
-- ----------------------------
DROP TABLE IF EXISTS `rolepermissions`;
CREATE TABLE `rolepermissions`  (
  `RoledId` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `PermissionsId` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `OrganizationScope` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`RoledId`, `PermissionsId`, `OrganizationScope`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of rolepermissions
-- ----------------------------
INSERT INTO `rolepermissions` VALUES ('069d0865-02b4-488b-8446-acb1fe956751', 'Delete', '1');
INSERT INTO `rolepermissions` VALUES ('069d0865-02b4-488b-8446-acb1fe956751', 'Delete', '4cba486f-a98e-4d95-8746-551304bbae03');
INSERT INTO `rolepermissions` VALUES ('069d0865-02b4-488b-8446-acb1fe956751', 'Delete', '866d150f-ba37-4c99-b608-5bd95b9a7fc6');
INSERT INTO `rolepermissions` VALUES ('744ef098-794c-4c94-b3e6-71b3220b5de6', 'Query', '1');
INSERT INTO `rolepermissions` VALUES ('744ef098-794c-4c94-b3e6-71b3220b5de6', 'Query', '4cba486f-a98e-4d95-8746-551304bbae03');
INSERT INTO `rolepermissions` VALUES ('744ef098-794c-4c94-b3e6-71b3220b5de6', 'Query', '866d150f-ba37-4c99-b608-5bd95b9a7fc6');
INSERT INTO `rolepermissions` VALUES ('744ef098-794c-4c94-b3e6-71b3220b5de6', 'Query', 'bda28aeb-8403-4a6d-af3e-5a1b88bfdbb1');
INSERT INTO `rolepermissions` VALUES ('744ef098-794c-4c94-b3e6-71b3220b5de6', 'Query', 'd132fcd8-5d44-46f1-a1d6-deee3983218c');
INSERT INTO `rolepermissions` VALUES ('744ef098-794c-4c94-b3e6-71b3220b5de6', 'Query', 'd6d9ae8e-2f74-4053-9888-affafd11dffb');

-- ----------------------------
-- Table structure for userrole
-- ----------------------------
DROP TABLE IF EXISTS `userrole`;
CREATE TABLE `userrole`  (
  `UserId` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `RoleId` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `IsDeleted` bit(1) NULL DEFAULT NULL,
  PRIMARY KEY (`UserId`, `RoleId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
