--[[
    GD50
    Super Mario Bros. Remake

    Author: Colton Ogden
    cogden@cs50.harvard.edu
]]

PlayerJumpState = Class { __includes = BaseState }

function PlayerJumpState:init(player, gravity)
    self.player = player
    self.gravity = gravity
    self.animation = Animation {
        frames = { 3 },
        interval = 1
    }
    self.player.currentAnimation = self.animation
end

function PlayerJumpState:enter(params)
    gSounds['jump']:play()
    self.player.dy = PLAYER_JUMP_VELOCITY
end

function PlayerJumpState:update(dt)
    self.player.currentAnimation:update(dt)
    self.player.dy = self.player.dy + self.gravity
    self.player.y = self.player.y + (self.player.dy * dt)

    -- go into the falling state when y velocity is positive
    if self.player.dy >= 0 then
        self.player:changeState('falling')
    end

    self.player.y = self.player.y + (self.player.dy * dt)

    -- look at two tiles above our head and check for collisions; 3 pixels of leeway for getting through gaps
    local tileLeft = self.player.map:pointToTile(self.player.x + 3, self.player.y)
    local tileRight = self.player.map:pointToTile(self.player.x + self.player.width - 3, self.player.y)

    -- if we get a collision up top, go into the falling state immediately
    if (tileLeft and tileRight) and (tileLeft:collidable() or tileRight:collidable()) then
        self.player.dy = 0
        self.player:changeState('falling')

        -- else test our sides for blocks
    elseif love.keyboard.isDown('left') then
        self.player.direction = 'left'
        self.player.x = self.player.x - PLAYER_WALK_SPEED * dt
        self.player:checkLeftCollisions(dt)
    elseif love.keyboard.isDown('right') then
        self.player.direction = 'right'
        self.player.x = self.player.x + PLAYER_WALK_SPEED * dt
        self.player:checkRightCollisions(dt)
    end

    -- check if we've collided with any collidable game objects
    for k, object in pairs(self.player.level.objects) do
        if object:collides(self.player) then
            if object.texture == 'keys-locks' and object.consumable then
                self.player.hasKey = true
            end
            if object.solid then
                -- if object.texture == 'keys-locks' and object.consumable then
                --     self.player.hasKey = true
                -- end
                object.onCollide(object)
                if self.player.hasKey and object.texture == 'keys-locks' then
                    self.player.blockWasDestroyed = true
                    table.remove(self.player.level.objects, k)
                    table.insert(self.player.level.objects,
                        GameObject {
                            texture = 'flag',
                            x = GlobalSelf * 16 - 16,
                            y = 3 * 16,
                            width = 16,
                            height = 16,
                            frame = 1,
                        }
                    )
                    table.insert(self.player.level.objects,
                        GameObject {
                            texture = 'flagtop',
                            x = GlobalSelf * 16 - 8,
                            y = 3 * 16,
                            width = 16,
                            height = 16,
                            frame = 7,
                        }
                    )
                end
                self.player.y = object.y + object.height
                self.player.dy = 0
                self.player:changeState('falling')
            elseif object.consumable then
                -- if object.texture == 'keys-locks' then
                --     self.hasKey = true
                -- end
                object.onConsume(self.player)
                table.remove(self.player.level.objects, k)
            end
        end
    end

    -- check if we've collided with any entities and die if so
    for k, entity in pairs(self.player.level.entities) do
        if entity:collides(self.player) then
            gSounds['death']:play()
            gStateMachine:change('start')
        end
    end
end
